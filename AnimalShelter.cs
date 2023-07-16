using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimalShelter
{   

    public partial class AnimalShelter : Form
    {
        public Customer[] CustomerArray= new Customer[10];
        public int CustomerArrayIndex = 0;


        //클래스를 이벤트 내부에서 선언하면 이벤트가 끝날때 데이터가 전부 사라져버림-> 필드에 선언하여 유지시킴
        //public Customer Cus1;

        public AnimalShelter()
        {
            InitializeComponent();
        }

        private void CreateCustomer_Click(object sender, EventArgs e)
        {

            /* 배열만들기
            // [] 안에 사이즈를 안적는게 좋음 적으면 배열 크기가 정해지므로 초기화할 떄 없이 사용
            int[] numberArray = new int[] { 1, 2, 3, 4, 5 };
            int[] numberArray2 = { 1, 2, 3, 4, 5 };

            //클래스 배열 만들기
            Customer[] customerArray = new Customer[5];
            customerArray[0] = new Customer("first", "last", new DateTime(2000, 1, 1));
            customerArray[1] = new Customer("first", "last", new DateTime(2000, 1, 1));
            customerArray[2] = new Customer("first", "last", new DateTime(2000, 1, 1));
            customerArray[3] = new Customer("first", "last", new DateTime(2000, 1, 1));
            customerArray[4] = new Customer("first", "last", new DateTime(2000, 1, 1));

            Customer[] customerArray2 =
            {
            new Customer("first", "last", new DateTime(2000, 1, 1)),
            new Customer("first", "last", new DateTime(2000, 1, 1)),
            new Customer("first", "last", new DateTime(2000, 1, 1)),
            new Customer("first", "last", new DateTime(2000, 1, 1)),
            new Customer("first", "last", new DateTime(2000, 1, 1))
            };
            */

            //입력으로 들어온 부분
            CustomerArray[CustomerArrayIndex] = new Customer(CusNewFirstName.Text, CusNewLastName.Text, 
                DateTime.Parse(CusNewBirthday.Text));
            CustomerArray[CustomerArrayIndex].Address = CusNewAddress.Text;
            CustomerArray[CustomerArrayIndex].Description = CusNewDescription.Text;

            CustomerList.Items.Add(CustomerArray[CustomerArrayIndex].FirstName);

            CustomerArrayIndex = CustomerArrayIndex + 1;
            CINDEX.Text = CustomerArrayIndex.ToString();


            /* 보여주는 부분의 텍스트에 넣어줌
            CusFullName.Text = Cus1.FullName;
            CusAge.Text = Cus1.Age.ToString();
            CusAddress.Text = Cus1.Address;
            CusIsQualified.Text = Cus1.IsQualified.ToString();
            CusDescription.Text = Cus1.Description;

            DateTime date = new DateTime(2016, 2, 5);
            // 클릭 발생시 현재 시간을 저장
            DateTime current = DateTime.Now; 
            */

        }

        public void ShowDetails(Customer cus)
        {
            CusFullName.Text = cus.FullName;
            CusAge.Text = cus.Age.ToString();
            CusAddress.Text = cus.Address;
            CusDescription.Text = cus.Description;
            CusIsQualified.Text = cus.IsQualified.ToString();
           
        }

        private void CustomerList_Click(object sender, EventArgs e)
        {
            string firstName = CustomerList.SelectedItem.ToString();

            for (int index = 0; index < CustomerArrayIndex; index++ )
            {
                if (CustomerArray[index].FirstName == firstName)
                {
                    ShowDetails(CustomerArray[index]);
                    break;

                }
            }
        }
    }
}
