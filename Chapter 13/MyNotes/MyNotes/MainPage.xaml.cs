using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Data.Linq; 
using System.Data.Linq.Mapping; 
using Microsoft.Phone.Data.Linq.Mapping; 

namespace MyNotes
{
    public partial class NoteDB : DataContext
    {
        public Table<Note> Notes;
        public NoteDB(string connection) : base(connection) { }
    }

    [Table]
    public class Note
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int NoteID { get; set; }

        [Column(CanBeNull = false)]
        public DateTime WrittenDate { get; set; }

        [Column(CanBeNull = false)]
        public string Content { get; set; }
    }

    public partial class MainPage : PhoneApplicationPage
    {

        NoteDB noteDB;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // 데이터 컨텍스트 생성하기
            noteDB = new NoteDB("isostore:/NoteDB1.sdf");

            // 데이터베이스 파일이 없으면 새로 생성한다.
            if (!noteDB.DatabaseExists())
                noteDB.CreateDatabase();

            ShowList();
        }

        private void ShowList()
        {
            // 데이터베이스에서 NoteID 내림차순으로 목록을 가져온다.
            var notes = from note in noteDB.Notes
                        orderby note.NoteID descending
                        select note;

            // ListBox 컨트롤에 바인딩 시키기
            listNote.ItemsSource = notes;

        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            // 데이터베이스에 새로운 노트 추가하기
            Note note = new Note();
            note.WrittenDate = DateTime.Now;
            note.Content = txtNote.Text;

            noteDB.Notes.InsertOnSubmit(note);
            noteDB.SubmitChanges();

            ShowList();
        }

        private void listNote_LostFocus(object sender, RoutedEventArgs e)
        {
            // 리스트 항목을 벗어나면 삭제 버튼을 숨긴다.
            this.ApplicationBar.IsVisible = false;
        }

        private void listNote_GotFocus(object sender, RoutedEventArgs e)
        {
            // 리스트 항목이 선택되면 삭제 버튼을 활성화한다.
            if (listNote.SelectedItems.Count > 0)
                this.ApplicationBar.IsVisible = true;
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            // 선택된 항목을 데이터베이스에서 삭제한다.
            var delNote = (from note in noteDB.Notes
                           where note.NoteID == Int32.Parse(listNote.SelectedValue.ToString())
                           select note).FirstOrDefault();

            noteDB.Notes.DeleteOnSubmit(delNote);
            noteDB.SubmitChanges();

            ShowList();
        }

    }
}