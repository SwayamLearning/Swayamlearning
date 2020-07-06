using System.Collections;
using System.Data;

/// <summary>
/// Summary description for Forum_BAL
/// </summary>
public class Forum_BAL
{
    DataAccess oDataHelper;
    ArrayList arrParameter;

    public Forum_BAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public bool Forum_Insert(Forum Forum)
    {
        this.oDataHelper = new DataAccess();
        this.arrParameter = new ArrayList();

        this.arrParameter.Add(new parameter("Post", Forum.Post));
        this.arrParameter.Add(new parameter("PostedBy", Forum.PostedBy));

        return this.oDataHelper.DAL_InsertUpdateWithStatus("Forum_Insert", this.arrParameter);
    }

    public DataSet Forum_Select_All(Forum Forum)
    {
        oDataHelper = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("PostedBy", Forum.PostedBy));
        
        return oDataHelper.DAL_Select("Forum_Select_ByPostedBy", arrParameter);
    }

    public DataSet Forum_Select_All_Userwise(Forum Forum)
    {
        oDataHelper = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("UserID", Forum.UserID));
        arrParameter.Add(new parameter("BMSID", Forum.BMSID));

        return oDataHelper.DAL_Select("StudentTeacherForum_SelectQuery", arrParameter);
    }

    public bool Forum_InsertQuery(Forum Forum)
    {
        this.oDataHelper = new DataAccess();
        this.arrParameter = new ArrayList();

        this.arrParameter.Add(new parameter("UserID", AppSessions.StudentID));
        this.arrParameter.Add(new parameter("RoleID", AppSessions.RoleID));
        this.arrParameter.Add(new parameter("BMSID", AppSessions.BMSID));
        this.arrParameter.Add(new parameter("BMSSCTID", Forum.BMSSCTID));
        this.arrParameter.Add(new parameter("Question", Forum.Post));
        this.arrParameter.Add(new parameter("UserName", Forum.UserName));
       return this.oDataHelper.DAL_InsertUpdateWithStatus("Insert_StudentTeacherForum", this.arrParameter);
    }

    public DataSet Select_BMSSCTID(Forum Forum)
    {
        this.oDataHelper = new DataAccess();
        this.arrParameter = new ArrayList();

        this.arrParameter.Add(new parameter("BMSID", Forum.BMSID));
        this.arrParameter.Add(new parameter("SubjectID", Forum.SubjectID));
        this.arrParameter.Add(new parameter("ChapterID", Forum.ChapterID));
        this.arrParameter.Add(new parameter("TopicID", Forum.TopicID));
        return this.oDataHelper.DAL_Select("Select_BMSSCTID", this.arrParameter);
    }

}