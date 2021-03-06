#region CHANGELOG
/*
 * Axios Engine
 * 
 * By: Nathan Adams
 * 
 * CHANGELOG
 * 
 * 1.0.0.0
 * - Initial Version
 * 
 * 1.0.0.1
 * - Adding staic function SetResolution
 * 
 * 1.0.0.2
 * - Adding flag when removing object from Farseer to prevent it from getting removed twice
 * 
 * 1.0.0.3
 * - Axios.Engine.File namespace
 *      - Adding title file reading support 
 *      - Adding iosloated file storage support
 *      
 * 1.0.0.4 - 3/9/2012
 * - Condensing AddGameObject into a single method
 * 
 * 1.0.0.5 - 3/9/2012
 * - Adding checks in MenuScreen to make sure screen doesn't get struck in transition
 * 
 * 1.0.0.6 - 3/10/2012
 * - Added Singleton class
 * - Added Logging class
 * - Added LoggingFlag flags
 * - Added static loglevel setting
 * - Moving some enums out of classes
 * - Adding AxiosRegularFile class
 * 
 * 1.0.0.7 - 3/11/2012
 * - Adding IAxiosFile interface
 * 
 * 1.0.0.8 - 3/15/2012
 * - Adding code for breakable bodies
 * 
 * 1.0.0.9 - 3/16/2012
 * - Changeing the complex objects alot - now they are more like "chained" objects
 * - Adding checks for if objects are getting deleted too fast
 * 
 * 1.0.1.0 - 3/20/2012
 * - Taking out hard coded debug statements for the screen system
 * - Adding field to allow/disallow automated mouse joints per object
 * - Fixing bug with last screen not exiting if it is a background screen
 * 
 * 1.0.1.1 - 3/22/2012
 * - Fixing UI collision with mouse pointer
 * - Adding AxiosRectangle and AxiosPoint classes
 * - Adding properties in DrawableAxiosGameObject to turn on/off the following:
 *   - AdjustUnits
 *   - RelativeToCamera
 * - Cleaning and sorting using statements
 *
 * 1.0.1.2 - 4/1/2012
 * - Making AxiosTimer inheirt from AxiosGameObject for it to be casted properly
 * 
 * 1.0.1.3 - 4/7/2012
 * - Adding a check in the AxiosTimer update to only tick if the game is active
 * 
 * 1.0.1.4 - 4/27/2012
 * - Merging the new GSM
 * 
 * 1.0.1.5 - 5/5/2012
 * - Adding SplitFlat extension for Texture2D
 * - Removing uneeded Game Screen checking code
 * - Adding SplitFlat extension with offsets for Texture2D
 * - Adding support for Gleed2D
 * - Splitting the code for Gleed2D into seperate files
 * - Adding a cache for loading in textures for Gleed2D
 * - Adding GetStream(FileMode) to get the stream of a file
 * - Adding support to load a Gleed2D level from a stream
 * - Adjusting units for Gleed2D position for Farseer bodies
 * - Modfying draw method in AxiosGameScreen to draw Gleed2D textures
 * - Fixing path placement in Farseer
 * - Moving base.draw to last in AxiosGameScreen to make sure Farseer debug information is visible
 * - Removing old debugging code
 * - Adding an extension to determine what side the objects collided on
 * - Correcting misspelling of Extensions in String and Texture2D
 * 
 * 1.0.1.6 - 5/18/2012
 * - Adding cut extension - [Author: BJD]
 * - Adding support for custom handling of Gleed2D items
 * - Changing location of GetTexture to extensions
 * - Enabling commented log messages
 * - Fixing bug where loadrecentangleitem wouldn't be called by Gleed2D library
 * - Changing AxiosTitleFile.GetStream() to return Stream instead of FileStream
 * - Changing IAxiosFile.GetStream() to return Stream instead of FileStream
 * - Adding support for XNACC
 * - Fixed a bug where cleanup actions were being performed in Deactivate instead of Unload in AxiosGameScreen
 * - Adding IsNullOrWhiteSpace extension for support for Xbox 360
 * - Upon some testing - developers will need to use #if WINDOWS/#endif tags to make sure they can't use XNACC in WP7/Xbox360
 * - Adding axioslog command to output AxiosLog
 * - Changing variables in CommandConsoleBase to be non-static
 * - Adding rotation to DrawableAxiosGameObject
 * - Adding InputState extensions to test for input agaisnt Player One
 * - Adding the ability to disable commands in XNACC from AxiosCommandConsole
 * - Adding a behavior in AxiosGameScreen where the camera will be controllable via
 * arrow keys in DEBUG releases and disabled in RELEASE releases. This behavior can
 * be overwritten in each screen
 * - Adding output to tcc console command to signal if it was disabled/enabled
 * - Adding DegreeToRadian/RadianToDegree double extensions
 * - Fixing UI detect bug
 * - Adding Width/Height/Position/RealPosition to DrawableAxiosGameObject
 * - Starting work on AxiosCSV
 * - Adding CustomProperties field to Glee2D Layer object (this is because Layers can have custom properties)
 * - Passing Layer to Items in Glee2D library
 * - Adding public virtual bool LoadTextureItem(TextureItem textureitem) to AxiosGameScreen
 * 
 * 1.0.1.7 - 7/22/2012
 * - Adding Factory for Texture2D to create from a list (ie lay a list of texture2D row by row)
 * - Adding AddScreen method to ScreenManager to make the PlayerIndex optional (default of PlayerIndex.One)
 * - Adding visible flag to DrawableAxiosGameObject and SimpleDrawableAxiosGameObject
 * - Adding extension to mousestate (Position) to get a Vector2 object of the position
 * - Added MouseAimVector to AGS - this allows you to get a vector to "shoot" with (realtive to the mouse and another object) a LinearVelocity in Farseer
 * 
 * 1.0.1.8 - 1/12/2012
 * - Adding UseSecondStep flag in PhysicsGameScreen (default false)
 * 
 * 1.0.1.9 - 5/20/2013
 * - Adding mono support
 * 
 * 1.0.1.10 - 11/29/2014
 * - Adding prompt factory class to generate a Final Fantasy type text prompt
 * - Updating Gleed2D support to work with latest version of Gleed2D
 * 
 * 1.0.1.11 - 
 * - Adding game services static class
 * - Removing cache from Gleed2D as ContentManager automatically does this
 * - Adding cache
 * - Adding XOR Shift random class
 * - Adding extension for rectangleitem to get position in Farseer units ( getSimPosition )
 * - Adding extension for vector2 to convert back and forth between sim and display units
 * - Fixing axios log flag detection
 * - Adding dispose methods to AxiosFile objects
 * - Adding extended log to AxiosLog
 * - Fixing issue in CommandConsole where the first line would not be displayed
 * - Adding Deactivate event for when the screen leaves focus
 * - Added flag to enable/disable moving camera with gamepad
 * 
 */
#endregion

using System.Reflection;
using Axios.Engine.Log;
using Microsoft.Xna.Framework;

namespace Axios
{
    public enum ResolutionSetting
    {
        Windows,
        Xbox360,
        WP7_Portrait,
        WP7_Landscape
    }
    public static class Settings
    {
       

        public static LoggingFlag Loglevel = LoggingFlag.ALL;

#if WINDOWS
        public static string Version = "Axios Engine " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
#elif XBOX360 || WINDOWS_PHONE
        private static AssemblyName assemblyref = new AssemblyName(Assembly.GetExecutingAssembly().FullName);
        public static string Version = "Axios Engine " + Settings.assemblyref.Version;
#endif

        public static bool ScreenSaver = false;

        private static ResolutionSetting _ressetting;
        /// <summary>
        /// We should have two seperate resolutions for seperate devices.
        /// This way you can have one source to preform calculations on world size depending on the device.
        /// </summary>
        public static void SetResolution(GraphicsDeviceManager graphics, ResolutionSetting setting)
        {
            //height is first
            graphics.PreferredBackBufferHeight = GetResolution(setting)[0];
            graphics.PreferredBackBufferWidth = GetResolution(setting)[1];
            _ressetting = setting;
        }

        private static int[] GetResolution(ResolutionSetting setting)
        {
            int[] screendim = new int[2];
            screendim[0] = 0;
            screendim[1] = 0;
            if (setting == ResolutionSetting.Windows || setting == ResolutionSetting.Xbox360)
            {
                screendim[0] = 720;
                screendim[1] = 1280;
            }
            
            if (setting == ResolutionSetting.WP7_Landscape)
            {
                screendim[0] = 480;
                screendim[1] = 800;
                
            } else if (setting == ResolutionSetting.WP7_Portrait)
            {
                screendim[0] = 800;
                screendim[1] = 480;
            }
        
            return screendim;
        }

        public static float GetHeightScale()
        {
            if (_ressetting == ResolutionSetting.WP7_Landscape || _ressetting == ResolutionSetting.WP7_Portrait)
            {
                return (float)GetResolution(_ressetting)[0] / (float)GetResolution(ResolutionSetting.Windows)[0];
            }
            else
            {
                return 1f;
            }
        }

        public static float GetWidthScale()
        {
            if (_ressetting == ResolutionSetting.WP7_Landscape || _ressetting == ResolutionSetting.WP7_Portrait)
            {
                return (float)GetResolution(_ressetting)[1] / (float)GetResolution(ResolutionSetting.Windows)[1];
            }
            else
            {
                return 1f;
            }
        }

        public static float GetScale()
        {
            return GetHeightScale() / GetWidthScale();
        }


        public static float DisplayUnitToSimUnitRatio = 24f;
    }
}