# ImageDownsizer
This is a WinForms application which down-sizes images. The app lets the user upload an image, choose a downscaling factor and then click the button for consequential or parallel downscalling. Upon finishing the process the user can save the resized image. The downscalling algorithm implements a nearest neighbor approach coupled with weight averaging for color interpolation.
# Results 
When downscaling small images the consequential approach has the same or even better speed, but for larger images the parallel aproach finishes the processing in about half the time.
