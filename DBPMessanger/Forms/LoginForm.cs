using DBPMessanger.infos;
using DBPMessanger.Config;
using Microsoft.EntityFrameworkCore;


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;

namespace DBPMessanger.Forms
{
    public partial class LoginForm : Form
    {
        private readonly AppDBContext db; // 
        public UserInfo? LoggedInUser { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
            db = new AppDBContext(); 

        }

        // 로그인 처리 로직
        private void PerformLogin(string loginId, string password)
        {
            try
            {
                button_login.Enabled = false; // 중복 클릭 방지

                var user = db.Users.FirstOrDefault(u => u.LoginId == loginId); // 사용자 조회

                if (user == null)
                {
                    MessageBox.Show("존재하지 않는 사용자입니다.", "로그인 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (user.Password != password)
                {
                    MessageBox.Show("비밀번호가 올바르지 않습니다.", "로그인 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (user.Role == null)
                {
                    // 역할이 할당되지 않으면 USER로 기본 설정
                    user.Role = ROLE.USER;
                }

                LoggedInUser = user; // 로그인 성공 사용자 설정

                // 로그인 기록 저장 + 시간 기록
                var log = new LoginLog
                {
                    UserId = user.Id,
                    LoginTime = DateTime.Now
                };
                db.LoginLogs.Add(log);
                db.SaveChanges(); // 여기서 id 생성 + 저장

                // 세션 저장
                SessionContext.CurrentUser = user;
                SessionContext.CurrentLoginLogId = log.Id;

                MessageBox.Show("로그인 성공!", "로그인", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException ex) // 예외 처리
            {
                var detail = ex.InnerException?.Message ?? ex.Message;
                MessageBox.Show($"DB 저장 오류: {detail}", "로그인 실패",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) // 예외 처리
            {
                MessageBox.Show($"일반 오류: {ex.Message}", "로그인 실패",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                button_login.Enabled = true;
            }
        }

        // 로그인 버튼 클릭 이벤트
        private void button_login_Click(object sender, EventArgs e)
        {
            var loginId = textBox_ID.Text.Trim();
            var password = textBox_PW.Text;

            if (loginId.Length == 0 || password.Length == 0)
            {
                MessageBox.Show("ID와 비밀번호를 입력하세요.", "로그인", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PerformLogin(loginId, password); // 로그인 처리 호출
        }
        protected override void OnFormClosed(FormClosedEventArgs e) // 폼 닫힐 때 DB 해제
        {
            db.Dispose(); // DB 컨텍스트 해제
            base.OnFormClosed(e); // 기본 동작 호출
        }

        // 최근 로그인 사용자 한 명 조회 (없으면 null 반환)
        private UserInfo? GetLastLoggedInUser()
        {
            try
            {
                return db.LoginLogs
                    .Include(l => l.User)
                    .AsNoTracking()
                    .OrderByDescending(l => l.LoginTime)
                    .Select(l => l.User)
                    .FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        // ID, PW 자동 입력 체크박스
        private void checkBox_auto_ID_PW_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox_auto_ID_PW.Checked) // 체크 해제 시 입력란 초기화
            {
                textBox_ID.Clear();
                textBox_PW.Clear();

                return;
            }

            var lastUser = GetLastLoggedInUser(); // 최근 로그인 사용자 조회

            if (lastUser == null)
            {
                MessageBox.Show("최근 로그인 기록이 없습니다.", "자동 입력", MessageBoxButtons.OK, MessageBoxIcon.Information);
                checkBox_auto_ID_PW.Checked = false;
                return;
            }

            textBox_ID.Text = lastUser.LoginId;
            textBox_PW.Text = lastUser.Password;
        }

        // 자동 로그인 체크박스
        private void checkBox_auto_login_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox_auto_login.Checked) // 체크 해제 시 동작 없음
                return;

            var lastUser = GetLastLoggedInUser(); // 최근 로그인 사용자 조회

            if (lastUser == null)
            {
                MessageBox.Show("최근 로그인 기록이 없어 자동 로그인을 수행할 수 없습니다.", "자동 로그인", MessageBoxButtons.OK, MessageBoxIcon.Information);
                checkBox_auto_login.Checked = false;
                return;
            }

            // ID/PW 자동 입력 체크가 꺼져 있어도 자동 로그인 위해 채움
            textBox_ID.Text = lastUser.LoginId;
            textBox_PW.Text = lastUser.Password;

            PerformLogin(lastUser.LoginId, lastUser.Password); // 자동 로그인 시도
        }
    }
}
