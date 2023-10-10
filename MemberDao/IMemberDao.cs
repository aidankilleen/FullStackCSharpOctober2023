namespace MemberDao
{
    public interface IMemberDao
    {
        string ConnectionString { get; set; }

        Member Add(Member member);
        void Close();
        void Delete(int id);
        Member Get(int id);
        List<Member> GetAll();
        Member Update(Member member);
    }
}