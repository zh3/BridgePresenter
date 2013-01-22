using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Office.Core;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;

namespace BridgePresenter.Model
{
    public class SlideShowManager : ISlideShowManager
    {
        private PowerPoint.Application _application;
        private PowerPoint.Presentations _applicationPresentations;

        public virtual void Show(IJointShow jointShow, bool launchShow)
        {
            List<IShow> shows = jointShow.ShowOrderShows;
            if (shows.Count == 0) return;

            _application = new PowerPoint.Application();
            _applicationPresentations = _application.Presentations;

            PowerPoint.Presentation joinedPresentation = _applicationPresentations.Add();

            for (int i = 0; i < shows.Count; i++)
            {
                PowerPoint.Presentation sourcePresentation
                    = _applicationPresentations.Open(shows[i].Path, MsoTriState.msoFalse, MsoTriState.msoTrue, MsoTriState.msoFalse);
                CopySlides(sourcePresentation, joinedPresentation);
                sourcePresentation.Close();
            }

            if (launchShow)
                joinedPresentation.SlideShowSettings.Run();
        }

        private void CopySlides(PowerPoint.Presentation sourcePresentation, PowerPoint.Presentation destPresentation)
        {
            PowerPoint.Slides sourceSlides = sourcePresentation.Slides;
            PowerPoint.Slides destSlides = destPresentation.Slides;

            for (int i = 1; i <= sourceSlides.Count; i++)
            {
                sourceSlides[i].Copy();

                if (destSlides.Count > 0)
                    destSlides[destSlides.Count].Select();

                destSlides.Application.CommandBars.ExecuteMso("PasteSourceFormatting");
                Application.DoEvents();
            }
        }
    }
}
