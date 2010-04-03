/*
 * UTAC - USB TEMPer Advanced Control
 * -----------------------------------------------------------------------
 * Homepage: http://utac.n4rf.net
 * Bugtracker: http://bugtracker.n4rf.net
 * SourceForge Project Page: http://sourceforge.net/projects/utac/
 * Mail Contact: info@n4rf.net
 * -----------------------------------------------------------------------
 * 
 * UTAC is a GUI for the TEMPer and TEMPerHum USB Thermometer
 * Copyright (C) Bjoern Boettcher 2008
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 * 
 * -----------------------------------------------------------------------
 * --------------------------------------------------* File Information *-
 * -----------------------------------------------------------------------
 * FileName: 	TempHumEntity.cs
 * Namespace: 	utac.Components.AveragingSystem
 * Author: 		siglr (guy@siglr.com)
 * Created: 	2008-04-29
 * -----------------------------------------------------------------------
 * -------------------------------------------------------- Description *-
 * -----------------------------------------------------------------------
 * This class holds the values for temperature and humidity for a specific 
 * snapshot in time
 */

namespace utac.Components.AveragingSystem
{
    /// <summary>
    /// This class holds the values for temperature and humidity for a specific snapshot in time
    /// </summary>
    sealed internal class TempHumEntity
    {

        #region Attributes

        private double _TempC;
        public double TempC
        {
            get { return _TempC; }
            set { _TempC = value; }
        }

        private double _Humidity;
        public double Humidity
        {
            get { return _Humidity; }
            set { _Humidity = value; }
        }

        private bool _Valid;
        public bool Valid
        {
            get { return _Valid; }
            set { _Valid = value; }
        }

        #endregion

        /// <summary>
        /// Constructor of the class
        /// </summary>
        /// <param name="tempC">Temperature in Celcius</param>
        /// <param name="humidity">Humidity in percent</param>
        /// <param name="valid">Is this a real value or is it only for initialization purposes</param>
        public TempHumEntity(double tempC, double humidity, bool valid)
        {
            TempC = tempC;
            Humidity = humidity;
            Valid = valid;

        }

    }

}
