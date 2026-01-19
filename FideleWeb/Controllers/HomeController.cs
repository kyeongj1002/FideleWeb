using FideleWeb.Models;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System.Diagnostics;

namespace FideleWeb.Controllers
{
    public class HomeController : Controller
    {
        // DB 접속 정보 (appsettings.json에서 가져올 열쇠)
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index() // 사용자가 처음 들어오면 실행되는 함수
        {
            // 1. 데이터를 담을 빈 리스트 준비 (Member 리스트)
            List<Member> members = new List<Member>();

            // 2. appsettings.json에서 "전화번호(접속주소)" 꺼내오기
            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            // 3. DB 연결 시작! (Using을 쓰면 다 쓰고 알아서 문 닫아줌)
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open(); // 똑똑! 문 열어주세요.

                // 4. SQL 쿼리 날리기 (명령)
                string sql = "SELECT * FROM Member"; // "회원 다 내놔"
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        // 5. 데이터 한 줄씩 읽어서 그릇(Member)에 담기
                        while (reader.Read())
                        {
                            Member member = new Member();
                            member.MemberId = Convert.ToInt32(reader["MemberId"]);
                            member.Name = reader["Name"].ToString();
                            member.BaptismalName = reader["BaptismalName"].ToString();
                            member.Phone = reader["Phone"].ToString();

                            // 리스트에 추가
                            members.Add(member);
                        }
                    }
                }
            }

            // 6. 다 담은 도시락(Model)을 손님(View)에게 전달!
            return View(members);
        }
    }
}
