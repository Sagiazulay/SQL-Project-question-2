using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlProject
{
    class Tests
    {
        public int ID { get; set; }

        public int Car_id { get; set; }

        public int Is_passed { get; set; }

        public DateTime Timestamp { get; set; }

        public Tests()
        {

        }

        public Tests(int iD, int car_id, int is_passed, DateTime timestamp)
        {
            ID = iD;
            Car_id = car_id;
            Is_passed = is_passed;
            Timestamp = DateTime.Now;
        }
        public override string ToString()
        {
            return $"{Newtonsoft.Json.JsonConvert.SerializeObject(this).Replace(",", "\n")}";
        }

        public override bool Equals(object obj)
        {
            return this.ID == ((Tests)obj).ID;
        }

        public override int GetHashCode()
        {
            return (int)ID;
        }
        public static bool operator ==(Tests test1, Tests test2)
        {
            return test1.ID == test2.ID;
        }
        public static bool operator !=(Tests test1, Tests test2)
        {
            return !(test1 == test2);
        }
    }
}
