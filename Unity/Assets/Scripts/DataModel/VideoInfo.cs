using System;
using System.Collections.Generic;

public class VideoInfo
{
	public string video_id;
	public string timestamp;
	public string title;
	public List<VideoFromat> formats;
}

public class VideoFromat{
	public string url;
	public string container;
	public string audioEncoding;
	public int audioBitrate;
}