using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Forum
/// </summary>
public class Forum
{
	public Forum()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    string post;

    public string Post
    {
        get { return post; }
        set { post = value; }
    }

    int postedby;

    public int PostedBy
    {
        get { return postedby; }
        set { postedby = value; }
    }

    int _BMSSCTID;

    public int BMSSCTID
    {
        get { return _BMSSCTID; }
        set { _BMSSCTID = value; }
    }
    int _BMSID;

    public int BMSID
    {
        get { return _BMSID; }
        set { _BMSID = value; }
    }

    int _SubjectID;

    public int SubjectID
    {
        get { return _SubjectID; }
        set { _SubjectID = value; }
    }
    int _ChapterID;

    public int ChapterID
    {
        get { return _ChapterID; }
        set { _ChapterID = value; }
    }

    int _TopicID;

    public int TopicID
    {
        get { return _TopicID; }
        set { _TopicID = value; }
    }

    int _UserID;

    public int UserID
    {
        get { return _UserID; }
        set { _UserID = value; }
    }

    string _UserName;
    public string UserName
    {
        get { return _UserName; }
        set { _UserName = value; }
    }

}
     
