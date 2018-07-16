public static bool EnabledVersion(string userAgent, string ver = "8.3.")
{
    var regex = new Regex(REGEX_VERSION);
    var m = regex.Match(userAgent);
    if (!m.Success)
    {
        return false;
    }

    var version = m.Value.Replace(m.Groups[1].Value, "").Trim().Replace("_", ".").Split('.');
    var aVer = ver.Split('.');
    int index = aVer.Length >= version.Length ? aVer.Length : version.Length;
    int lVer, rVer = 0;

    for (int i = 0; i < index - 1; i++)
    {
        lVer = int.Parse(version[i] + version[i + 1]);
        rVer = int.Parse(aVer[i] + aVer[i + 1]);

        if (lVer > rVer)
        {
            return true;
        }
        else if (lVer < rVer)
        {
            return false;
        }
    }

    return true;
}

public const string REGEX_VERSION = @"(Android|OS)\s(\d+(.|_)?)+\d+";
