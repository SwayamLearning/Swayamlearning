using System;
/*created for teacher registration 05th june 2019 R.Shyamala...*/

public class TeacherReg
{
    public TeacherReg()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    int _employeregid;
     
    string _firstname;
   
    string _lastname;
    
    string _emailid;
    Int32 _contactno;
    string _qualification;
     
    //byte _image;
    
    bool _isactive;
    string _CVpath;
    int _bmsid;
    int _subjectid;

    DateTime _createdon;
    int _createdby;
    DateTime _modifiedon;
    int _modifiedby;
    
    
    
    string _MobileNumber;

     
 

    public int Employeregid
    {
        get { return _employeregid; }
        set { _employeregid = value; }
    }

  
     

    public string firstname
    {
        get { return _firstname; }
        set { _firstname = value; }
    }


    

    public string lastname
    {
        get { return _lastname; }
        set { _lastname = value; }
    }

 

     

  

    public string emailid
    {
        get { return _emailid; }
        set { _emailid = value; }
    }


    public Int32 contactno
    {
        get { return _contactno; }
        set { _contactno = value; }
    }


    public string qualification
    {
        get { return _qualification; }
        set { _qualification = value; }
    }


    public string CVpath
    {
        get { return _CVpath; }
        set { _CVpath = value; }
    }




    public int bmsid
    {
        get { return _bmsid; }
        set { _bmsid = value; }
    }

    public int subjectid
    {
        get { return _subjectid; }
        set { _subjectid = value; }
    }
  
    byte[] _image = new byte[1024];
    public byte[] image
    {
        get { return _image; }
        set { _image = value; }
    }

    //public byte image
    //{
    //    get { return _image; }
    //    set { _image = value; }
    //}


   


    public bool isactive
    {
        get { return _isactive; }
        set { _isactive = value; }
    }


    public DateTime createdon
    {
        get { return _createdon; }
        set { _createdon = value; }
    }


    public int createdby
    {
        get { return _createdby; }
        set { _createdby = value; }
    }


    public DateTime modifiedon
    {
        get { return _modifiedon; }
        set { _modifiedon = value; }
    }


    public int modifiedby
    {
        get { return _modifiedby; }
        set { _modifiedby = value; }
    }
    public string MobileNumber
    {
        get { return _MobileNumber; }
        set { _MobileNumber = value; }
    }

}
