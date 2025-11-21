using System.Drawing;

namespace DBPMessanger.Controls
{
    public static class UITheme
    {
        // 기본 색상
        public static Color PrimaryColor = Color.FromArgb(70, 130, 180);        // Steel Blue
        public static Color PrimaryDark = Color.FromArgb(50, 100, 150);
        public static Color PrimaryLight = Color.FromArgb(100, 160, 210);

        // 보조 색상
        public static Color SecondaryColor = Color.FromArgb(100, 149, 237);     // Cornflower Blue
        public static Color AccentColor = Color.FromArgb(255, 193, 7);          // Amber

        // 배경 색상
        public static Color BackgroundColor = Color.FromArgb(245, 247, 250);    // Light Gray Blue
        public static Color SurfaceColor = Color.White;
        public static Color CardBackground = Color.FromArgb(255, 255, 255);

        // 텍스트 색상
        public static Color TextPrimary = Color.FromArgb(33, 33, 33);
        public static Color TextSecondary = Color.FromArgb(117, 117, 117);
        public static Color TextDisabled = Color.FromArgb(189, 189, 189);
        public static Color TextOnPrimary = Color.White;

        // 구분선 및 테두리
        public static Color DividerColor = Color.FromArgb(224, 224, 224);
        public static Color BorderColor = Color.FromArgb(200, 200, 200);
        public static Color FocusBorderColor = Color.FromArgb(70, 130, 180);

        // 상태 색상
        public static Color SuccessColor = Color.FromArgb(76, 175, 80);         // Green
        public static Color WarningColor = Color.FromArgb(255, 152, 0);         // Orange
        public static Color ErrorColor = Color.FromArgb(244, 67, 54);           // Red
        public static Color InfoColor = Color.FromArgb(33, 150, 243);           // Blue

        // 호버 및 선택 색상
        public static Color HoverColor = Color.FromArgb(240, 242, 245);
        public static Color SelectedColor = Color.FromArgb(230, 240, 250);
        public static Color PressedColor = Color.FromArgb(220, 230, 240);

        // 즐겨찾기 색상
        public static Color FavoriteColor = Color.FromArgb(255, 215, 0);        // Gold

        // 그림자 색상
        public static Color ShadowColor = Color.FromArgb(30, 0, 0, 0);

        // 폰트
        public static Font DefaultFont = new Font(new FontFamily("Segoe UI"), 9.5F, FontStyle.Regular);
        public static Font HeaderFont = new Font(new FontFamily("Segoe UI"), 14F, FontStyle.Bold);
        public static Font SubHeaderFont = new Font(new FontFamily("Segoe UI"), 11F, FontStyle.Bold);
        public static Font SmallFont = new Font(new FontFamily("Segoe UI"), 8.5F, FontStyle.Regular);

        // 둥글기 반경
        public static int BorderRadiusSmall = 8;
        public static int BorderRadiusMedium = 12;
        public static int BorderRadiusLarge = 16;

        // 간격
        public static int PaddingSmall = 8;
        public static int PaddingMedium = 12;
        public static int PaddingLarge = 16;
    }
}
