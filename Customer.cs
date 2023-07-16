using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter
{
    public class Customer
    {
        public string FirstName;
        public string LastName;
        private int _Age;
        private bool _IsQualified;
        public string Description;
        public string Address;
        private DateTime _BirthDay; 



        public Customer(string firstName, string lastName, int age, DateTime birthday)
        { 
            this.FirstName = firstName;
            this.LastName = lastName;
            this._Age = age;
            this._BirthDay = birthday;
            this._IsQualified = DateTime.Now.Year - birthday.Year >= 18;

        }

        public int GetAge()
        {
            return this._Age;
        }

        public DateTime Birthday
        { 
            get { return this._BirthDay; }
            set 
            {
                this._BirthDay = value;
                _IsQualified = Age >= 18;
            }
        }
        /*
        public void SetAge(int age)
        {
            _Age = age;
            _IsQualified = age >= 18;
        }
        */

        // Age 라는 속성을 정의
        public int Age
        {   // get 메소드는 매개변수가 없어야댐 무조건 리턴
            get { return DateTime.Now.Year - _BirthDay.Year; }
            // set 메소드는 매개변수가 하나여야하고 그게 속성이랑 같아야됌
            set 
            {   //인트형으로 들어온 매개변수 = value
                // 따라서 간단하게 조작해서 저장하거나 리턴하거나 조건을 걸어 필드 값을 보호할때 사용 
                _Age = value;
                _IsQualified = Age >= 18;
            }
        }
        /*
        public bool GetIsQualified()
        {
            return _IsQualified;
        }
        */
        public bool IsQualified 
        {
            get 
            {   /// private 속성을 접근하기 위해 읽기전용으로 만들때 사용
                return _IsQualified; 
            } 
        }
        //속성으로 만들면 훨씬 깔끔함
        public string FullName
        {
            get { return this.FirstName + " " + this.LastName ; }
        }

        /*
        public string GetFullName()
        { 
            return FirstName + " " + LastName;
        }
        */





    }
}
