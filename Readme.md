<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))
<!-- default file list end -->
# How to enhance the output quality of a chart in its Print Preview


<p>You can export a <strong>ChartControl</strong> into a WMF file format, and then use the resulting file in the Print Preview. This will improve the quality of a chart in its print preview.</p><p><strong>Note</strong>: Look at the project attached to this article to see this feature implementation.<br />
<strong>Note</strong>: This solution works correctly only for 2D chart views. Unfortunately, it's impossible to export a 3D chart into a metafile, because it uses <strong>OpenGL</strong> functions for drawing.</p><p>See also: <a href="https://www.devexpress.com/Support/Center/p/E2031">E2031</a>.</p>

<br/>


