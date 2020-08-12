using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Gateway
{
    public class AllocateClassRoomGateWay
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public AllocateClassRoomGateWay()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["universityManagementConString"]
                .ConnectionString;
            connection = new SqlConnection(connectionString);
        }
        public bool IsAllocated(int courseId)
        {
            string query = "SELECT * FROM AllocatedClassRoom Where CourseId=@courseId AND Allocated=1";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@courseId", courseId);
            connection.Open();
            reader = command.ExecuteReader();
            reader.Read();
            bool isAssigned = reader.HasRows;
            connection.Close();

            return isAssigned;

        }

        public int Save(AllocateClassRoom classRoom)
        {
            string query =
                "INSERT INTO AllocatedClassRoom(CourseId,RoomId,WeekDayId,FromTime,ToTime) Values(@courseId,@roomId,@weekDayId,@fromTime,@toTime)";
            command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@courseId", classRoom.CourseId);
            command.Parameters.AddWithValue("@roomId", classRoom.RoomId);
            command.Parameters.AddWithValue("@weekDayId", classRoom.DayId);
            command.Parameters.AddWithValue("@fromTime", classRoom.FromTime);
            command.Parameters.AddWithValue("@toTime", classRoom.ToTime);
            

            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;

        }

        public List<Room> GetAllRoom()
        {
        string query = "SELECT * FROM Room ORDER BY Name ASC";
        command = new SqlCommand(query,connection);
        connection.Open();
        reader = command.ExecuteReader();
        List<Room> roomList = new List<Room>();
            while (reader.Read())
        {
            Room aRoom = new Room();
            aRoom.Id = Convert.ToInt32(reader["Id"]);
            aRoom.Name = reader["Name"].ToString();

            roomList.Add(aRoom);
        }
        reader.Close();
        connection.Close();

        return roomList;
        }

        public List<Day> GetAllDay()
        {
            string query = "SELECT * FROM WeekDay ORDER BY Name ASC";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<Day> dayList = new List<Day>();
            while (reader.Read())
            {
                Day aDay = new Day();
                aDay.Id = Convert.ToInt32(reader["Id"]);
                aDay.Name = reader["Name"].ToString();

                dayList.Add(aDay);
            }
            reader.Close();
            connection.Close();

            return dayList;
        }

        public List<AllocateClassRoom> GetTimeSheduleByDayAndRoomId(int dayId,int roomId)
        {
            string query = "SELECT * FROM AllocatedClassRoom WHERE WeekDayId=@dayId AND RoomId=@roomId";
            command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@dayId", dayId);
            command.Parameters.AddWithValue("@roomId", roomId);

            connection.Open();
            reader = command.ExecuteReader();
            List<AllocateClassRoom> allocateClassRoomList = new List<AllocateClassRoom>();
            while (reader.Read())
            {
                AllocateClassRoom allocateClassRoom = new AllocateClassRoom();
                allocateClassRoom.FromTime = reader["FromTime"].ToString();
                allocateClassRoom.ToTime = reader["ToTime"].ToString();

                allocateClassRoomList.Add(allocateClassRoom);
            }
            reader.Close();
            connection.Close();

            return allocateClassRoomList;
        }

        public List<ClassRoomScedule> GetClassRoomSceduleByDepartmentId(int departmentId)
        {
            string query = "SELECT * FROM ScheduleInformation WHERE DepartmentId = @departmentId ORDER BY Code ASC, Day ASC, FromTime ASC";
            command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@departmentId", departmentId);
            connection.Open();
            reader = command.ExecuteReader();
            List<ClassRoomScedule> classRoomSceduleList = new List<ClassRoomScedule>();
            while (reader.Read())
            {
                ClassRoomScedule classRoomScedule = new ClassRoomScedule();
                classRoomScedule.CourseCode = reader["Code"].ToString();
                classRoomScedule.CourseName = reader["Name"].ToString();
                classRoomScedule.Room = reader["Room"].ToString();
                classRoomScedule.Day = reader["Day"].ToString();
                classRoomScedule.FromTime = reader["FromTime"].ToString();
                classRoomScedule.ToTime = reader["ToTime"].ToString();

                classRoomSceduleList.Add(classRoomScedule);
            }
            reader.Close();
            connection.Close();

            int len = classRoomSceduleList.Count;

            for (int i = 0; i < len - 1; i++)
            {
                for (int j = i; j < len; j++)
                {
                    if (i==j)
                    {
                        classRoomSceduleList[i].ClassScheduleInfo = "R. No : " + classRoomSceduleList[i].Room + ", " + classRoomSceduleList[i].Day + ", " + classRoomSceduleList[i].FromTime + " - " +
                            classRoomSceduleList[i].ToTime + ";";
                    }
                    else if (classRoomSceduleList[i].CourseName == classRoomSceduleList[j].CourseName)
                    {
                        classRoomSceduleList[i].ClassScheduleInfo += "<br/>";
                        classRoomSceduleList[i].ClassScheduleInfo += "R. No : " + classRoomSceduleList[j].Room + ", " + classRoomSceduleList[j].Day + ", " + classRoomSceduleList[j].FromTime + " - " +
                           classRoomSceduleList[j].ToTime + ";";

                        classRoomSceduleList.RemoveAt(j);
                        len -= 1;
                        j--;
                    }

                }
            }

            for (int i = 0; i < len; i++)
            {
                if (classRoomSceduleList[i].Room == "")
                {
                    classRoomSceduleList[i].ClassScheduleInfo = "Not Scheduled Yet";
                }
            }
            return classRoomSceduleList;
        }
		
		public int UnallocateRooms()
        {
            string query =
               "UPDATE AllocatedClassRoom SET Allocated= 0";
            command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;
        }
    }
}