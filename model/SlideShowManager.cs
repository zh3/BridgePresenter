using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Office.Core;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;

namespace BridgePresenter.Model
{
    public class SlideShowManager : ISlideShowManager
    {
        public virtual void Show(IJointShow jointShow, bool launchShow)
        {
            List<IShow> shows = jointShow.ShowOrderShows;
            if (shows.Count == 0) return;

            PowerPoint.Application application = new PowerPoint.Application();
            PowerPoint.Presentations applicationPresentations = application.Presentations;

            PowerPoint.Presentation joinedPresentation = applicationPresentations.Add();

            for (int i = 0; i < shows.Count; i++)
            {
                PowerPoint.Presentation sourcePresentation
                    = applicationPresentations.Open(shows[i].Path, MsoTriState.msoFalse, MsoTriState.msoTrue, MsoTriState.msoFalse);
                CopySlides(sourcePresentation, joinedPresentation);

                sourcePresentation.Close();
                Marshal.ReleaseComObject(sourcePresentation);
            }
            
            if (launchShow)
            {
                PowerPoint.SlideShowSettings slideShowSettings = joinedPresentation.SlideShowSettings;
                slideShowSettings.Run();

                GC.Collect();
                GC.WaitForPendingFinalizers();
                Marshal.ReleaseComObject(slideShowSettings);
            }

            Marshal.ReleaseComObject(joinedPresentation);
            Marshal.ReleaseComObject(applicationPresentations);
            Marshal.ReleaseComObject(application);
        }

        private void CopySlides(PowerPoint.Presentation sourcePresentation, PowerPoint.Presentation destPresentation)
        {
            PowerPoint.Slides sourceSlides = sourcePresentation.Slides;
            PowerPoint.Slides destSlides = destPresentation.Slides;

            for (int i = 1; i <= sourceSlides.Count; i++)
            {
                PowerPoint.Slide slide = sourceSlides[i];
                slide.Copy();

                if (destSlides.Count > 0)
                {
                    PowerPoint.Slide destSlide = destSlides[destSlides.Count];
                    destSlide.Select();

                    Marshal.ReleaseComObject(destSlide);
                }

                PowerPoint.Application application = destSlides.Application;
                application.CommandBars.ExecuteMso("PasteSourceFormatting");
                Application.DoEvents();

                Marshal.ReleaseComObject(application);
                Marshal.ReleaseComObject(slide);
            }

            Marshal.ReleaseComObject(sourceSlides);
            Marshal.ReleaseComObject(destSlides);
        }
    }
}
