using System.ComponentModel.DataAnnotations;

namespace FideleWeb.Models
{
    public class Member
    {
        // 고유번호 (PK)
        public int MemberId { get; set; }

        // 로그인 아이디
        public string LoginId { get; set; }

        // 비밀번호
        public string Password { get; set; }

        // 이름 (실명)
        public string Name { get; set; }

        // 세례명
        public string BaptismalName { get; set; }

        // 축일 (예: 12-25)
        public string? FeastDate { get; set; } // ?는 "비어있어도 됨(NULL 허용)" 뜻

        // 전화번호
        public string Phone { get; set; }

        // 구역
        public string? Area { get; set; }

        // 권한 (Member, Admin 등)
        public string UserRole { get; set; }

        // 가입일
        public DateTime JoinDate { get; set; }
    }
}
