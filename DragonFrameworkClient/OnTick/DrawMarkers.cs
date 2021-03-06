﻿using System;
using System;
using System.Collections.Generic;
using MenuAPI;
using CitizenFX.Core;
using CitizenFX.Core.UI;
using static CitizenFX.Core.UI.Screen;
using static CitizenFX.Core.Native.API;
using System.Threading.Tasks;

namespace DragonFrameworkClient
{
    class DrawMarkers : BaseScript
    {
        public List<BlipMarkerData> Blips = new List<BlipMarkerData>();
        public bool AreBlipsMade;
        int Car;
        public class BlipMarkerData
        {
            public float X;
            public float Y;
            public float Z;
            public int? SpriteID;
            public string Name;
            public int? Blip;
            public BlipMarkerData(float x, float y, float z, int? spriteid, string name)
            {
                X = x;
                Y = y;
                Z = z;
                SpriteID = spriteid;
                Name = name;
                Blip = null;
            }
        }

        public DrawMarkers()
        {
            Tick += tDrawMarkers;
            
        }
        private async Task tDrawMarkers() { DrawMarkersAndBlips(); }

        public void DrawMarkersAndBlips()
        {
            if (!AreBlipsMade) { LoadBlipData(); return; }

            if (!Game.PlayerPed.IsInVehicle() && !Game.PlayerPed.IsGettingIntoAVehicle && Game.PlayerPed.LastVehicle != null && Car == -5)
            {
                Car = AddBlipForCoord(Game.PlayerPed.LastVehicle.Position.X, Game.PlayerPed.LastVehicle.Position.Y, Game.PlayerPed.LastVehicle.Position.Z);
                SetBlipSprite((int)Car, 225);
                SetBlipAsShortRange((int)Car, true);
            }
            else if (Game.PlayerPed.IsInVehicle() && Car != -5)
            {

                RemoveBlip(ref Car);
                Car = -5;
            }

            foreach (BlipMarkerData data in Blips)
            {
                DrawMarker(1, data.X, data.Y, data.Z, 0, 0, 0, 0, 0, 0, 3, 3, 1, 250, 232, 117, 255, false, true, 2, false, null, null, false);

                if (data.SpriteID != null && data.Blip == null)
                {
                    int blip = AddBlipForCoord(data.X, data.Y, data.Z);
                    SetBlipSprite(blip, (int)data.SpriteID);
                    SetBlipAsShortRange(blip, true);
                    data.Blip = blip;
                }
            }
        }

        public void LoadBlipData()
        {
            AreBlipsMade = false;

            Blips.Clear();

            #region Misc.
            Blips.Add(new BlipMarkerData(3540.75f, 3675.86f, 27f, null, "Humane"));
            Blips.Add(new BlipMarkerData(3540.75f, 3675.86f, 20f, null, "Humane"));

            Blips.Add(new BlipMarkerData(-2051.5f, 3237.1f, 30f, null, "Facility"));
            Blips.Add(new BlipMarkerData(2155.12f, 2920.95f, -63f, null, "Facility"));
            Blips.Add(new BlipMarkerData(2033.73f, 2942.2f, -63f, null, "Facility"));
            Blips.Add(new BlipMarkerData(2155f, 2921.05f, -82.1f, null, "Facility"));
            #endregion

            #region Barbers
            Blips.Add(new BlipMarkerData(-813.71356201172f, -184.06265258789f, 36f, 71, "Barber"));
            Blips.Add(new BlipMarkerData(136.97842407227f, -1707.8671875f, 28f, 71, "Barber"));
            Blips.Add(new BlipMarkerData(-1282.8363037109f, -1116.9685058594f, 5.8f, 71, "Barber"));
            Blips.Add(new BlipMarkerData(1931.7169189453f, 3730.3142089844f, 31f, 71, "Barber"));
            Blips.Add(new BlipMarkerData(1212.4298095703f, -472.55453491211f, 65f, 71, "Barber"));
            Blips.Add(new BlipMarkerData(-32.703586578369f, -152.55470275879f, 56f, 71, "Barber"));
            Blips.Add(new BlipMarkerData(-278.02655029297f, 6228.3115234375f, 30f, 71, "Barber"));
            #endregion

            #region Clothing store
            Blips.Add(new BlipMarkerData(72.2545394897461f, -1399.10229492188f, 28f, 73, "Clothing"));
            Blips.Add(new BlipMarkerData(-703.77685546875f, -152.258544921875f, 36f, 73, "Clothing"));
            Blips.Add(new BlipMarkerData(-167.863754272461f, -298.969482421875f, 38f, 73, "Clothing"));
            Blips.Add(new BlipMarkerData(428.694885253906f, -800.1064453125f, 28f, 73, "Clothing"));
            Blips.Add(new BlipMarkerData(-829.413269042969f, -1073.71032714844f, 10f, 73, "Clothing"));
            Blips.Add(new BlipMarkerData(-1193.42956542969f, -772.262329101563f, 16f, 73, "Clothing"));
            Blips.Add(new BlipMarkerData(-1447.7978515625f, -242.461242675781f, 48f, 73, "Clothing"));
            Blips.Add(new BlipMarkerData(11.6323690414429f, 6514.224609375f, 30f, 73, "Clothing"));
            Blips.Add(new BlipMarkerData(1696.29187011719f, 4829.3125f, 41f, 73, "Clothing"));
            Blips.Add(new BlipMarkerData(123.64656829834f, -219.440338134766f, 53f, 73, "Clothing"));
            Blips.Add(new BlipMarkerData(618.093444824219f, 2759.62939453125f, 41f, 73, "Clothing"));
            Blips.Add(new BlipMarkerData(1190.55017089844f, 2713.44189453125f, 37f, 73, "Clothing"));
            Blips.Add(new BlipMarkerData(-3172.49682617188f, 1048.13330078125f, 19f, 73, "Clothing"));
            Blips.Add(new BlipMarkerData(-1108.44177246094f, 2708.92358398438f, 18f, 73, "Clothing"));
            #endregion

            #region Tattoo store
            Blips.Add(new BlipMarkerData(1322.645f, -1651.976f, 51f, 75, "Tattoo"));
            Blips.Add(new BlipMarkerData(-1153.676f, -1425.68f, 3f, 75, "Tattoo"));
            Blips.Add(new BlipMarkerData(322.139f, 180.467f, 102f, 75, "Tattoo"));
            Blips.Add(new BlipMarkerData(-3170.071f, 1075.059f, 19f, 75, "Tattoo"));
            Blips.Add(new BlipMarkerData(1864.633f, 3747.738f, 32f, 75, "Tattoo"));
            Blips.Add(new BlipMarkerData(-293.713f, 6200.04f, 30f, 75, "Tattoo"));
            #endregion

            #region Gun store
            Blips.Add(new BlipMarkerData(-662.1f, -935.3f, 20f, 110, "Gun"));
            Blips.Add(new BlipMarkerData(1693.4f, 3759.5f, 33f, 110, "Gun"));
            Blips.Add(new BlipMarkerData(-330.2f, 6083.8f, 29f, 110, "Gun"));
            Blips.Add(new BlipMarkerData(252.3f, -50.0f, 68f, 110, "Gun"));
            Blips.Add(new BlipMarkerData(2567.6f, 294.3f, 107f, 110, "Gun"));
            Blips.Add(new BlipMarkerData(-1117.5f, 2698.6f, 18f, 110, "Gun"));
            Blips.Add(new BlipMarkerData(842.4f, -1033.4f, 27f, 110, "Gun"));
            Blips.Add(new BlipMarkerData(810.2f, -2157.3f, 28f, 313, "GunRange"));
            Blips.Add(new BlipMarkerData(22.0f, -1107.2f, 28f, 313, "GunRange"));
            #endregion

            AreBlipsMade = true;
        }
    }
}
