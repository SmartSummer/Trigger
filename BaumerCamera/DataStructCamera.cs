using System;
public struct BX_ImageInfo
{
    public byte[] ImageBuffer;
    public IntPtr ImagePoint;
    public uint ImageSize;
    public BX_ImageInfoPixFormatType PixelFormat;
    public uint SizeHeight;
    public uint SizeWidth;
    public uint stride;
}

public enum BX_ImageInfoPixFormatType
{
    BX_PixFormatMONO8 = 0,
    BX_PixFormatBGR8 = 1,
}
public enum ETRIGGERMODE
{
    SOFTWARE,
    HARDWARE,
    CONTINUE
}
public struct RangleValue
{
    public string value { get; set; }
    public string max { get; set; }
    public string min { get; set; }
    public string inc { get; set; }
}

public delegate void getImageInfor(BX_ImageInfo imageInfo);