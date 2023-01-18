using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    internal class CarEntity
    {
        public String CarId { get; set; }
        public String CarName { get; set; }
        public int CarNumber { get; set; }
        private double carSpeed;
        public double CarSpeed
        { 
            // CarSpeed = 250.5 will be called setter
            get { return carSpeed; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Speed value must be greater than 0");
                }
                carSpeed = value;
            }
        }

        public static CarBuilder Builder()
        {
            return new CarBuilder();
        }

        public override string ToString()
        {
            return new StringBuilder(CarId).Append(' ')
                .Append(CarName)
                .Append(' ')
                .Append(CarNumber)
                .Append(' ')
                .Append(CarSpeed)
                .ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is CarEntity entity &&
                   CarId == entity.CarId &&
                   CarName == entity.CarName &&
                   CarNumber == entity.CarNumber &&
                   CarSpeed == entity.CarSpeed;
        }

        public override int GetHashCode()
        {
            int hashCode = -1606179882;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CarId);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CarName);
            hashCode = hashCode * -1521134295 + CarNumber.GetHashCode();
            hashCode = hashCode * -1521134295 + CarSpeed.GetHashCode();
            return hashCode;
        }


        public class CarBuilder {
            CarEntity carEntity = new CarEntity();

            public CarBuilder CarId(String carId)
            {
                carEntity.CarId = carId;
                return this;
            }

            public CarBuilder CarName(String carName)
            {
                carEntity.CarName = carName;
                return this;
            }

            public CarBuilder CarNumber(int carNumber)
            {
                carEntity.CarNumber = carNumber;
                return this;
            }

            public CarBuilder CarSpeed(double carSpeed)
            {
                carEntity.CarSpeed = carSpeed;
                return this;
            }

            public CarEntity Build()
            {
                return carEntity;
            }
        }
    }

}
