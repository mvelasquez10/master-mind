using System.Security.Cryptography;
using System.Text;

namespace ConsoleUI
{
    internal static class SecretFeature
    {
        #region Internal Fields

        internal static string message = "DQoNCiAvXF8vXCAgL1xfL1wgIC9cXy9cICAvXF8vXCAgL1xfL1wgIC9cXy9cICAvXF8vXCAgL1xfL1wgIC9cXy9cICAvXF8vXCAgL1xfL1wgDQooIG8ubyApKCBvLm8gKSggby5vICkoIG8ubyApKCBvLm8gKSggby5vICkoIG8ubyApKCBvLm8gKSggby5vICkoIG8ubyApKCBvLm8gKQ0KID4gXiA8ICA+IF4gPCAgPiBeIDwgID4gXiA8ICA+IF4gPCAgPiBeIDwgID4gXiA8ICA+IF4gPCAgPiBeIDwgID4gXiA8ICA+IF4gPCANCiAvXF8vXCAgIF8gICAgXyAgICAgICAgICAgICAgICAgICAgICAgICAgIF9fX18gICBfX19fXyAgICAgICAgICAgICAgICAgL1xfL1wgDQooIG8ubyApIHwgfCAgfCB8ICAgICAgICAgICAgICAgICAgICAgICAgIHwgIF8gXCB8ICBfXyBcICAgICAgICAgICAgICAgKCBvLm8gKQ0KID4gXiA8ICB8IHxfX3wgfCBfXyBfIF8gX18gIF8gX18gIF8gICBfICB8IHxfKSB8fCB8ICB8IHwgX18gXyBfICAgXyAgICA+IF4gPCANCiAvXF8vXCAgfCAgX18gIHwvIF9gIHwgJ18gXHwgJ18gXHwgfCB8IHwgfCAgXyA8IHwgfCAgfCB8LyBfYCB8IHwgfCB8ICAgL1xfL1wgDQooIG8ubyApIHwgfCAgfCB8IChffCB8IHxfKSB8IHxfKSB8IHxffCB8IHwgfF8pIHx8IHxfX3wgfCAoX3wgfCB8X3wgfCAgKCBvLm8gKQ0KID4gXiA8ICB8X3wgIHxffFxfXyxffCAuX18vfCAuX18vIFxfXywgfCB8X19fXyhfKV9fX19fLyBcX18sX3xcX18sIHwgICA+IF4gPCANCiAvXF8vXCAgICAgICAgICAgICAgIHwgfCAgIHwgfCAgICAgX18vIHwgICAgICAgICAgICAgICAgICAgICAgIF9fLyB8ICAgL1xfL1wgDQooIG8ubyApIF9fICAgICAgX19fICB8X3wgXyB8X3wgICAgfF9fXy8gICAgICAgICAgICAgICAgICAgICAgIHxfX18vICAgKCBvLm8gKQ0KID4gXiA8ICBcIFwgICAgLyAoXykgICAgfCB8ICAgICAgICB8IHwgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICA+IF4gPCANCiAvXF8vXCAgIFwgXCAgLyAvIF8gIF9fX3wgfCBfX18gICBffCB8ICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgL1xfL1wgDQooIG8ubyApICAgXCBcLyAvIHwgfC8gX198IHwvIC8gfCB8IHwgfCAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgKCBvLm8gKQ0KID4gXiA8ICAgICBcICAvICB8IHwgKF9ffCAgIDx8IHxffCB8X3wgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICA+IF4gPCANCiAvXF8vXCAgICAgIFwvICAgfF98XF9fX3xffFxfXFxfXywgKF8pICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgL1xfL1wgDQooIG8ubyApICAgICAgICAgICAgICAgICAgICAgICAgX18vIHwgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgKCBvLm8gKQ0KID4gXiA8ICAgICAgICAgICAgICAgICAgICAgICAgfF9fXy8gICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICA+IF4gPCANCiAvXF8vXCAgL1xfL1wgIC9cXy9cICAvXF8vXCAgL1xfL1wgIC9cXy9cICAvXF8vXCAgL1xfL1wgIC9cXy9cICAvXF8vXCAgL1xfL1wgDQooIG8ubyApKCBvLm8gKSggby5vICkoIG8ubyApKCBvLm8gKSggby5vICkoIG8ubyApKCBvLm8gKSggby5vICkoIG8ubyApKCBvLm8gKQ0KID4gXiA8ICA+IF4gPCAgPiBeIDwgID4gXiA8ICA+IF4gPCAgPiBeIDwgID4gXiA8ICA+IF4gPCAgPiBeIDwgID4gXiA8ICA+IF4gPCANCg0K";

        // Hint: 今日の日「二桁」と今日の月「一桁」
        internal static byte[] secretFeaure = {
            207, 188, 167, 37, 255, 131, 176, 26, 183, 172, 8, 177, 24, 73, 6, 21,
            35, 76, 227, 88, 203, 252, 244, 39, 60, 140, 155, 80, 115, 121, 85, 251
        };

        #endregion Internal Fields

        #region Internal Methods

        internal static bool CheckSecretFeature(string secretCode)
        {
            using (SHA256 sha256Hash = SHA256.Create())
                return secretFeaure.SequenceEqual(sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(secretCode)));
        }

        internal static void ShowSecretFeature()
        {
            Console.Clear();
            Console.WriteLine(Encoding.UTF8.GetString(Convert.FromBase64String(message)));
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            Environment.Exit(0);
        }

        #endregion Internal Methods
    }
}