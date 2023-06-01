using MudBlazor;

namespace Quantum.Presentation.Services;

public class ThemeProvider
{
    public MudTheme Theme = new MudTheme()
    {
        Palette = new Palette()
        {
            Primary = "#0077B6",
            PrimaryLighten = "#0096C7",
            PrimaryDarken = "#023E8A",
            PrimaryContrastText = "#D6F1FF",
            Secondary = "#FF8500",
            SecondaryLighten = "#FF9E00",
            SecondaryDarken = "#FF5400",
            SecondaryContrastText = "#FFEBD6",
            Tertiary = "#00B4D8",
            TertiaryLighten = "#0AD6FF",
            TertiaryDarken = "#0096C7",
            TertiaryContrastText = "#D8D8FE"
        },
        PaletteDark = new PaletteDark()
        {
            Primary = "#0077B6",
            PrimaryLighten = "#0096C7",
            PrimaryDarken = "#023E8A",
            PrimaryContrastText = "#D6F1FF",
            Secondary = "#FF8500",
            SecondaryLighten = "#FF9E00",
            SecondaryDarken = "#FF5400",
            SecondaryContrastText = "#FFEBD6",
            Tertiary = "#00B4D8",
            TertiaryLighten = "#0AD6FF",
            TertiaryDarken = "#0096C7",
            TertiaryContrastText = "#D8D8FE",
            Background = "#1f1f1f",
            DrawerBackground = "#2d2f31",
            BackgroundGrey = "#131313",
            Surface = "#28292a"
        }
    };

    public event Action? ThemeChange;
}