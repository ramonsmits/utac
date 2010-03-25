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
 * FileName: 	TempHumAvgEngine.cs
 * Namespace: 	utac.Components.AveragingSystem
 * Author: 		siglr (guy@siglr.com)
 * Created: 	2008-04-29
 * -----------------------------------------------------------------------
 * -------------------------------------------------------- Description *-
 * -----------------------------------------------------------------------
 * Main engine class for the averaging system.
 */

using System.Collections.Generic;

namespace utac.Components.AveragingSystem
{
    /// <summary>
    /// Main class
    /// </summary>
    public class TempHumAvgEngine
    {

        #region Attributes

        private Dictionary<int, TempHumEntity> _FullMinuteValues;
        private Dictionary<int, TempHumEntity> FullMinuteValues
        {
            get { return _FullMinuteValues; }
            set { _FullMinuteValues = value; }
        }

        private Dictionary<int, TempHumEntity> _FullHourValues;
        private Dictionary<int, TempHumEntity> FullHourValues
        {
            get { return _FullHourValues; }
            set { _FullHourValues = value; }
        }

        private int _FullMinuteValuesPosition;
        private int FullMinuteValuesPosition
        {
            get { return _FullMinuteValuesPosition; }
            set { _FullMinuteValuesPosition = value; }
        }

        private int _FullHourValuesPosition;
        private int FullHourValuesPosition
        {
            get { return _FullHourValuesPosition; }
            set { _FullHourValuesPosition = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor of the class - performs initialization
        /// </summary>
        public TempHumAvgEngine()
        {

            TempHumEntity fakeValue = new TempHumEntity(0, 0, false);

            //Initialize value containers
            FullMinuteValues = new Dictionary<int, TempHumEntity>();
            for (int i = 1; i < 13; i++)
            {
                FullMinuteValues.Add(i, fakeValue);
            }
            FullHourValues = new Dictionary<int, TempHumEntity>();
            for (int i = 1; i < 61; i++)
            {
                FullHourValues.Add(i, fakeValue);
            }

            FullMinuteValuesPosition = 1;
            FullHourValuesPosition = 1;

        }

        #endregion

        #region Methods

        /// <summary>
        /// Method to call every 5 seconds to record a value (temp and humidity)
        /// </summary>
        /// <param name="tempC">Temperature in Celcius</param>
        /// <param name="humidity">Humidity in percent</param>
        public void AddValue(double tempC, double humidity)
        {
            TempHumEntity newValue = new TempHumEntity(tempC, humidity, true);

            FullMinuteValues[FullMinuteValuesPosition] = newValue;
            FullMinuteValuesPosition += 1;

            if (FullMinuteValuesPosition == 13)
            {
                //Calculate average for the last 12 values (full minute) and put the result in the hour values container
                double totalTempC = 0;
                double totalHumidity = 0;
                for (int i = 1; i < 13; i++)
                {
                    totalTempC = totalTempC + FullMinuteValues[i].TempC;
                    totalHumidity = totalHumidity + FullMinuteValues[i].Humidity;
                }
                TempHumEntity newMinuteValue = new TempHumEntity(totalTempC / 12, totalHumidity / 12, true);
                FullHourValues[FullHourValuesPosition] = newMinuteValue;
                FullHourValuesPosition += 1;

                if (FullHourValuesPosition == 61)
                {
                    //Reset position
                    FullHourValuesPosition = 1;
                }

                //Reset position
                FullMinuteValuesPosition = 1;
            }

        }

        /// <summary>
        /// Method to call to get the average for the last x minutes
        /// </summary>
        /// <param name="lastXminutes">Number of minutes to use to calculate the average</param>
        /// <returns>A TempHumiditySet object</returns>
        public TempHumiditySet GetAverages(int lastXminutes)
        {
            TempHumiditySet result = new TempHumiditySet();
            double totalTempC = 0;
            double totalHumidity = 0;
            int totalCount = 0;

            int position = FullHourValuesPosition;
            TempHumEntity currentSet;

            //Need to start to the previous record - the last one if we're at the first one
            if (position == 1)
            {
                position = 60;
            }
            else
            {
                position = position - 1;
            }

            for (int i = 1; i < lastXminutes + 1; i++)
            {
                currentSet = FullHourValues[position];
                if (currentSet.Valid)
                {
                    totalTempC = totalTempC + currentSet.TempC;
                    totalHumidity = totalHumidity + currentSet.Humidity;
                    totalCount += 1;

                    //Back one position
                    position = position - 1;
                    if (position == 0)
                    {
                        position = 60;
                    }

                }
                else
                {
                    //We've reached invalid values that are part of the initialization - get out
                    break;
                }
            }

            if (totalCount > 0)
            {
                result.TempC = totalTempC / totalCount;
                result.Humidity = totalHumidity / totalCount;
            }

            return result;
        }

        #endregion

    }
}
