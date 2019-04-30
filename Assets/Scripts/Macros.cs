using Cradle;
using static Helpers;

public class Macros : Cradle.RuntimeMacros
{
    [RuntimeMacro]
    public void showImage(string name)
    {
        this.Story.SendMessage("showImage", name);
    }

    [RuntimeMacro]
    public void hideImage()
    {
        this.Story.SendMessage("hideImage");
    }

    [RuntimeMacro]
    public void playMusic(string name)
    {
        this.Story.SendMessage("playMusic", name);
    }

    [RuntimeMacro]
    public void stopMusic()
    {
        this.Story.SendMessage("stopMusic");
    }

    [RuntimeMacro]
    public void elvesExeShowJobAdvert()
    {
        this.Story.SendMessage("elvesExeShowJobAdvert");
    }

    [RuntimeMacro]
    public void protagonistWakeUp()
    {
        this.Story.SendMessage("protagonistWakeUp");
    }

    [RuntimeMacro]
    public void theEndMeaningOfLife()
    {
        this.Story.SendMessage("theEndMeaningOfLife");
    }

    [RuntimeMacro]
    public void showGameOver(string description)
    {
        PersistVars(this.Story);
        this.Story.SendMessage("showGameOver", description);
    }

    [RuntimeMacro]
    public void showText(string val)
    {
        this.Story.SendMessage("showText", val);
    }

    [RuntimeMacro]
    public void setDM(string val)
    {
        this.Story.SendMessage("setDM", val);
    }

    [RuntimeMacro]
    public void setSH(string val)
    {
        this.Story.SendMessage("setSH", val);
    }

    [RuntimeMacro]
    public void playSound(string name)
    {
        this.Story.SendMessage("playSound", name);
    }

    [RuntimeMacro]
    public void stopSound()
    {
        this.Story.SendMessage("stopSound");
    }

    [RuntimeMacro]
    public void delay(double seconds)
    {
        this.Story.SendMessage("delay", seconds);
    }
}
