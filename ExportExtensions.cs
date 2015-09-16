using System;
using AppKit;
using CoreGraphics;

namespace OxyPlot.Xamarin.Mac
{
	/// <summary>
	///	Export extensions for Images and PDF Documents
	/// </summary>
	public static class ExportExtensions
	{
		/// <summary>
		/// Generates the image.
		/// </summary>
		/// <returns>The image.</returns>
		/// <param name="view">View.</param>
		public static NSImage GenerateImage(this NSView view)
		{
			CGRect bounds = view.Bounds;

			NSBitmapImageRep bir = view.BitmapImageRepForCachingDisplayInRect (bounds);
			bir.Size = bounds.Size;
			view.CacheDisplay (bounds, bir);

			NSImage targetImage = new NSImage(bounds.Size);
			targetImage.LockFocus();
			bir.DrawInRect(bounds);
			targetImage.UnlockFocus();

			return targetImage;
		}
	}
}

