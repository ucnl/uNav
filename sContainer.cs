using UCNLDrivers;

namespace uNav
{
    public class sContainer : SimpleSettingsContainer
    {
        #region Properties

        public BaudRate InPortBaudrate;
        public BaudRate SerialBypassBaudrate;

        public int RWLT_Mode;
        public int RWLT_DRating;
        
        public bool IsAutoSalinity;
        public double Salinity_PSU;
        public bool IsAutoSoundSpeed;
        public double SoundSpeed_mps;
        public double WaterTemperature_C;

        public double TargetMaxSpeed_mps;

        public double TrackSmootherRangeThreshold_m;
        public int TrackSmootherFIFOSize;

        public double DHFilterRangeThreshold_m;
        public int DHFilterFIFOSize;

        public int CourseEstimatorFIFOSize;

        public int TrackPointsToShow;
        public int TileSizePx;

        public bool IsEmuEnabled;
        public string[] TileServers;

        public bool EnableTilesDownloading;

        #endregion

        #region Methods

        public override void SetDefaults()
        {
            InPortBaudrate = BaudRate.baudRate38400;
            SerialBypassBaudrate = BaudRate.baudRate38400;

            RWLT_Mode = 0;
            RWLT_DRating = 0;

            IsAutoSalinity = true;
            Salinity_PSU = UCNLPhysics.PHX.PHX_FWTR_SALINITY_PSU;
            IsAutoSoundSpeed = true;
            SoundSpeed_mps = UCNLPhysics.PHX.PHX_FWTR_SOUND_SPEED_MPS;
            WaterTemperature_C = 17;

            TargetMaxSpeed_mps = 1.0;

            TrackSmootherRangeThreshold_m = 100;
            TrackSmootherFIFOSize = 4;

            DHFilterRangeThreshold_m = 10;
            DHFilterFIFOSize = 8;

            CourseEstimatorFIFOSize = 4;

            TrackPointsToShow = 512;
            TileSizePx = 256;

            IsEmuEnabled = true;
            TileServers = new string[]
            {
                "https://a.tile.openstreetmap.org",
                "https://b.tile.openstreetmap.org",
                "https://c.tile.openstreetmap.org"
            };

            EnableTilesDownloading = false;
        }

        #endregion
    }
}
