using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GroupManager
    {
        private List<Group> groups;
        public List<Group> Groups 
        {
            get
            {
                return groups;
            }
            set
            {
                groups = value;
            }
        }
        public string OperationResult;

        public GroupManager()
        {
            DataManager dataManager = new DataManager();
            dataManager.SetData(ref groups);
        }

        public void AddGroup(string groupName, int Course)
        {
            if (Groups == null)
            {
                Groups = new List<Group>();
                Groups.Add(new Group(groupName, Course));
                OperationResult = $"Group {groupName} added";
            }
            else
            {
                bool isGroupExist = false;
                foreach (Group g in Groups)
                {
                    if (g.Name.Equals(groupName))
                    {
                        isGroupExist = true;
                        break;
                    }
                }

                if (isGroupExist == true)
                    OperationResult = "A group with this name already exists";
                else
                {
                    Groups.Add(new Group(groupName, Course));
                    OperationResult = $"Group {groupName} added";
                }
            }
           
        }

        public void DeliteGroup(string groupName)
        {
            try
            {
                List<Group> changedGroup = new List<Group>();

                bool isDeleted = false;
                foreach (Group g in Groups)
                {
                    if (g.Name.Equals(groupName))
                        isDeleted = true;
                    else
                        changedGroup.Add(g);
                }

                if (isDeleted == true)
                {
                    Groups = changedGroup;
                    OperationResult = $"Group {groupName} deleted";
                }
                else
                    OperationResult = $"There is no group named {groupName}";
            }
            catch (EntityNotFoundExeption ex)
            {
                OperationResult = ex.Message;
            }
        }

        public void ChangeGroupData(string groupName, string whatChanging, string newData)
        {
            try
            {
                Group group = GetGroup(groupName);

                if (whatChanging.Equals("Name"))
                {
                    group.Name = newData;
                    OperationResult = $"Group name changed to {newData}";
                }
                else if (whatChanging.Equals("Course"))
                {
                    group.Course = Int32.Parse(newData);
                    OperationResult = $"The course of the group and the course of students in the group changed to {newData}";
                }

            }
            catch (EntityNotFoundExeption ex)
            {
                OperationResult = ex.Message;
            }
        }

        public string GetAllGroupData(string groupName)
        {
            try
            {
                Group group = GetGroup(groupName);

                string subjects = "";
                foreach (string subjetcName in group.SubjectsName)
                {
                    subjects += '\t' + subjetcName;
                }

                if (subjects.Equals(""))
                    subjects = "This group doesn't have any sucjects";

                return $"Group {group.Name}\n" +
                    $"Course: {group.Course}\n" +
                    $"Count of students: {group.CountOfStudents}\n" +
                    $"Subjects: {subjects}";

            }
            catch (EntityNotFoundExeption ex)
            {
                return ex.Message;
            }
        }

        public string GetGroupDataOf(string groupName, string dataName)
        {
            try
            {
                Group group = GetGroup(groupName);

                if (dataName.Equals("Course"))
                    return $"Course: {group.Course}";
                else if (dataName.Equals("Count of students"))
                    return $"Count of students: {group.CountOfStudents}";
                else if (dataName.Equals("Subjects"))
                {
                    string subjects = "";
                    foreach (string subjetcName in group.SubjectsName)
                    {
                        subjects += subjetcName + '\t';
                    }
                    if (subjects.Equals(""))
                        return "This group doesn't have any subjects";
                    else
                        return $"Subjects: {subjects}";
                }
                else
                    return "Incorrect data name";
            }
            catch (EntityNotFoundExeption ex)
            {
                return ex.Message;
            }
        }



        public Group GetGroup(string groupName)
        {
            try
            {
                if (Groups == null)
                    throw new Exception("There are no groups");

                foreach (Group g in Groups)
                {
                    if (g.Name.Equals(groupName))
                    {
                        return g;
                    }
                }

                throw new Exception($"There is no group named {groupName}");
            }
            catch (Exception e)
            {
                throw new EntityNotFoundExeption(e.Message);
            }
        }


        public bool IsGroupExist(string groupName)
        {
            try
            {
                GetGroup(groupName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool IsDataExist()
        {
            if (Groups.Count == 0)
                return false;
            else
                return true;
        }
    }
}