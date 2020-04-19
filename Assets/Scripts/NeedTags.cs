using System.Collections;
using System.Collections.Generic;

public class NeedTags
{

    private NeedTags(string value)
    {
        Value = value;
    }

    public string Value { get; set; }

    public static NeedTags MEAT_TAG { get { return new NeedTags("Meat"); } }
    public static NeedTags BEER_TAG { get { return new NeedTags("Beer"); } }
    public static NeedTags POOP_TAG { get { return new NeedTags("Poop"); } }
    public static NeedTags BLEED_TAG { get { return new NeedTags("Bleed"); } }

}
