﻿using MP3Boss.Source.DataStructures;

namespace MP3Boss.Source.Validation
{
    public interface IVerify
    {
        string nullTagChecker(string tags);

        string checkFormMessage(bool reset = false);
    }
}
