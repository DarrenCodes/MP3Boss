using MP3Boss.Source.Datastructures;

namespace MP3Boss.Source.Validation
{
    public interface IVerify
    {
        string nullTagChecker(string tags);
        string nullTagChecker(Iterate tags);

        string checkFormMessage(bool reset = false);
    }
}
