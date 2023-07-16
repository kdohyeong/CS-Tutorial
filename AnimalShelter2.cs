using System;
using System.Collections;
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
        // 커스토머 클래스만 들어가는 리스트 만듬
        public List<Customer> Customers = new List<Customer>();


        // public Customer[] CustomerArray= new Customer[10];
        // public int CustomerArrayIndex = 0;


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
            Customer cus = new Customer(CusNewFirstName.Text, CusNewLastName.Text, 
                DateTime.Parse(CusNewBirthday.Text));
            cus.Address = CusNewAddress.Text;
            cus.Description = CusNewDescription.Text;

            CustomerList.Items.Add(cus.FirstName);

            //데이터 그리드뷰 -> 패널 깔고 위에 Fill 로 채움
            CusList.Rows.Add(cus.FirstName, cus.Age, cus.IsQualified);

            Customers.Add(cus);

            //++ 로 하면 왜 안됌?
            //CustomerArrayIndex = CustomerArrayIndex + 1;
            //CINDEX.Text = CustomerArrayIndex.ToString();


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

            foreach (Customer cus in Customers)
            { 
                if (cus.FirstName == firstName)
                { 
                    ShowDetails(cus);
                    break;
                }
            }

            /*
            for (int index = 0; index < CustomerArrayIndex; index++ )
            {
                if (CustomerArray[index].FirstName == firstName)
                {
                    ShowDetails(CustomerArray[index]);
                    break;

                }
            }
            */
        }

            /*
            // arraylist 생성 -> 오브젝트 데이터타입 -> 아무 데이터타입으로 다 변환가능
            ArrayList arrayList = new ArrayList();
            
            arrayList.Add(0);
            arrayList.Add(1);
            arrayList.Add(2);

            // (인덱스, 값)
            arrayList.Insert(2, 3);
            
            // 값
            arrayList.Remove(2);

            // 인덱스
            arrayList.RemoveAt(1);

            //count -> 요소의 수

            for (int index = 0; index < arrayList.Count; index++)
            {
                arrayList[index];
            
            }
            // 옵젝을 인트로 변환해서 계산가능
            int num = (int)arrayList[index];


            // 데이터를 저장할 때 형 변환을 안하고 사용하기 위해서 리스트를 씀
            int[] intArray = new int[5];
            ArrayList arrayList = new ArrayList();
            List<int> intList = new List<int>();

            // 리스트 T 는 제네릭 클래스이고 T라는 형만 따로 받으려고 만듬 -> 제네릭 컬렉션
            List<T>

            // 인트 리스트 생성
            List<int> intList = new List<int>();
            IntList.Add(1);
            IntList.Add(2);
            IntList.Add("Hi");

            // for문 보다 훨씬 깔끔함
            int sum = 0;
            foreach (int value in intList)
            {
                sum += value;
            }
            
            Customer

            */

        //  DataGridViewCellEventArgs 이안에 Row[e.RowIndex] 가 들어옴
        private void CusList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string firstName = (string)CusList.Rows[e.RowIndex].Cells[0].Value;
            foreach (Customer cus in Customers)
            {
                if (cus.FirstName == firstName)
                {
                    ShowDetails(cus);
                    break;
                }
            }

            CusDetailPanel.Show();
            CusNewPanel.Hide();

        }

        private void AnimalShelter_Load(object sender, EventArgs e)
        {
            CusListPanel.Dock = DockStyle.Fill;
            CusDetailPanel.Dock = DockStyle.Right;
            CusNewPanel.Dock = DockStyle.Right;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            CusNewPanel.Show();
            CusDetailPanel.Hide();
        }
    }
}
