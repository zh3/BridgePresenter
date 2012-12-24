using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Core;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;

namespace BridgePresenter.Model
{
    public class SlideShowManager : ISlideShowManager
    {
        private enum SlideShowPosition
        {
            ShowStart,
            ShowEnd
        }

        private PowerPoint.Application _application;
        private PowerPoint.Presentations _applicationPresentations;
        private PowerPoint.Presentation[] _openedPresentations;
        private PowerPoint.SlideShowWindow[] _openedWindows;
        private List<PowerPoint.Presentation> _existingPresentations; 

        private int _slideShowIndex = 0;
        public virtual void Show(IJointShow jointShow)
        {
            _application = new PowerPoint.Application();
            _applicationPresentations = _application.Presentations;

            List<IShow> shows = jointShow.ShowOrderShows;
            _openedPresentations = new PowerPoint.Presentation[shows.Count];
            _openedWindows = new PowerPoint.SlideShowWindow[shows.Count];
            _existingPresentations = _applicationPresentations.Cast<PowerPoint.Presentation>().ToList();

            for (int i = 0; i < shows.Count; i++)
            {
                _openedPresentations[i] 
                    = _applicationPresentations.Open(shows[i].Path, MsoTriState.msoFalse, MsoTriState.msoTrue, MsoTriState.msoFalse);
                AddDummySlides(_openedPresentations[i]);
                _openedWindows[i] = _openedPresentations[i].SlideShowSettings.Run();
            }


            _slideShowIndex = 0;
            ActivateSlideShow(0, SlideShowPosition.ShowStart);

            _application.SlideShowEnd += application_SlideShowEnd;
            _application.SlideShowNextSlide += application_SlideShowNextSlide;
        }

        private void AddDummySlides(PowerPoint.Presentation presentation)
        {
            PowerPoint.CustomLayout customLayout = presentation.SlideMaster.CustomLayouts[1];

            presentation.Slides.AddSlide(presentation.Slides.Count + 1, customLayout);
            presentation.Slides.AddSlide(1, customLayout);
        }
        
        private void application_SlideShowNextSlide(PowerPoint.SlideShowWindow Wn)
        {
            _application.SlideShowNextSlide -= application_SlideShowNextSlide;

            int slideIndex = Wn.View.Slide.SlideIndex;
            PowerPoint.Presentation openPresentation = Wn.Presentation;
            if (slideIndex == openPresentation.Slides.Count && _slideShowIndex < _openedPresentations.Length - 1)
            {
                _slideShowIndex++;
                ActivateSlideShow(_slideShowIndex, SlideShowPosition.ShowStart);
            }
            else if (slideIndex == 1)
            {
                MoveToPreviousPresentation();
            }

            _application.SlideShowNextSlide += application_SlideShowNextSlide;
        }

        private void MoveToPreviousPresentation()
        {
            if (_slideShowIndex > 0)
            {
                _slideShowIndex--;
                ActivateSlideShow(_slideShowIndex, SlideShowPosition.ShowEnd);
            }
            else
            {
                ActivateSlideShow(_slideShowIndex, SlideShowPosition.ShowStart);
            }
        }

        private void ActivateSlideShow(int index, SlideShowPosition position)
        {
            PowerPoint.SlideShowWindow window = _openedWindows[index];
            window.Activate();
            SetSlideShowPosition(window, position);
        }

        private void SetSlideShowPosition(PowerPoint.SlideShowWindow window, SlideShowPosition position)
        {
            switch (position)
            {
                case SlideShowPosition.ShowStart:
                    window.View.GotoSlide(2);
                    break;
                case SlideShowPosition.ShowEnd:
                    window.View.GotoSlide(window.Presentation.Slides.Count - 1);
                    break;
            }
        }

        void application_SlideShowEnd(PowerPoint.Presentation pres)
        {
            _application.SlideShowNextSlide -= application_SlideShowNextSlide;
            _application.SlideShowEnd -= application_SlideShowEnd;

            foreach (PowerPoint.Presentation presentation in _applicationPresentations)
            {
                if (!_existingPresentations.Contains(presentation))
                {
                    presentation.SlideShowWindow.View.Exit();
                    presentation.Close();
                }
            }
        }
    }
}
