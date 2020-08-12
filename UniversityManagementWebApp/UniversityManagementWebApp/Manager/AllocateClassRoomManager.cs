using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Gateway;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Manager
{
    public class AllocateClassRoomManager
    {
        private AllocateClassRoomGateWay allocateClassRoomGateWay;
        public AllocateClassRoomManager()
        {
            allocateClassRoomGateWay = new AllocateClassRoomGateWay();
        }

        public string Save(AllocateClassRoom classRoom)
        {
            
            if (!allocateClassRoomGateWay.IsAllocated(classRoom.CourseId))
            {
                int roAffect = allocateClassRoomGateWay.Save(classRoom);
                return "Room Allocation succesful";
            }
            int len1 = classRoom.FromTime.Length;
            int count = 0;
            int same = 0;
            if (classRoom.FromTime == classRoom.ToTime)
            {
                same = 1;
            }
            else
            {
                same = 0;
            }
            if (classRoom.FromTime.Contains("AM") && classRoom.ToTime.Contains("AM"))
            {
                for (int i = 0; i < len1; i++)
                {
                    if (classRoom.FromTime[i] > classRoom.ToTime[i])
                    {
                        count = 1;
                        break;
                    }
                    else
                    {
                        if (classRoom.ToTime[i] > classRoom.FromTime[i])
                        {
                            count = 0;
                            break;
                        }
                        else
                        {
                            count = 0;
                        }
                    }
                }
            }
            else
            {
                if (classRoom.FromTime.Contains("PM") && classRoom.ToTime.Contains("PM"))
                {
                    for (int i = 0; i < len1; i++)
                    {
                        if (classRoom.FromTime[i] > classRoom.ToTime[i])
                        {
                            count = 1;
                            break;
                        }
                        else
                        {
                            if (classRoom.ToTime[i] > classRoom.FromTime[i])
                            {
                                count = 0;
                                break;
                            }
                            else
                            {
                                count = 0;
                            }
                        }
                    }
                }
                else
                {
                    if (classRoom.FromTime.Contains("PM") && classRoom.ToTime.Contains("AM"))
                    {
                        count = 1;
                    }
                    else
                    {
                        count = 0;
                    }
                }
            }

            List<AllocateClassRoom> allocateClassRoomList =
                allocateClassRoomGateWay.GetTimeSheduleByDayAndRoomId(classRoom.DayId, classRoom.RoomId);
            string msg = "";
            foreach (AllocateClassRoom allocateClassRoom in allocateClassRoomList)
            {
                if (allocateClassRoom.FromTime == classRoom.FromTime)
                {
                    msg = "Overlaped";
                }
                else
                {
                    if (classRoom.FromTime == allocateClassRoom.ToTime)
                    {
                        msg = "";
                    }

                    else
                    {
                        int len = allocateClassRoom.FromTime.Length;
                        for (int i = 0; i < len - 1; i++)
                        {
                            if (classRoom.FromTime[i] > allocateClassRoom.FromTime[i] &&
                                classRoom.FromTime[i] <= allocateClassRoom.ToTime[i])
                            {
                                msg = "Overlaped";
                                break;
                            }
                            else
                            {
                                if ((classRoom.FromTime[i] < allocateClassRoom.FromTime[i]) &&
                                    (classRoom.FromTime[i] <= allocateClassRoom.ToTime[i]))
                                {
                                    msg = "Overlaped";
                                    break;
                                }
                                else
                                {
                                    msg = "";
                                }
                            }
                        }


                    }
                }
            }

            if (same == 1)
            {
                return "From Time and To time can not be same";
            }
            else
            {
                if (count == 1)
                {
                    return "From Time Can Not Be Grater Than To Time";
                }
                else
                {
                    if (msg == "Overlaped")
                    {
                        return "Ops! Time Scedule Overlaped";
                    }
                    else
                    {
                        if (allocateClassRoomGateWay.Save(classRoom) > 0)
                        {
                            return "Save Successful";
                        }
                        else
                        {
                            return "Save Failed!";
                        }
                    }
                }
            }
        }
        public List<Room> GetAllRoom()
        {
            return allocateClassRoomGateWay.GetAllRoom();
        }

        public List<SelectListItem> GetAllRoomForDropdown()
        {
            List<Room> rooms = allocateClassRoomGateWay.GetAllRoom();
            List<SelectListItem> selectListItems = new List<SelectListItem>()
            {
                new SelectListItem() {Text = "--Select--", Value = ""}
            };
            foreach (Room room in rooms)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = room.Name;
                selectListItem.Value = room.Id.ToString();
                selectListItems.Add(selectListItem);
            }

            return selectListItems;
        }

        public List<SelectListItem> GetAllDayForDropdown()
        {
            List<Day> days = allocateClassRoomGateWay.GetAllDay();
            List<SelectListItem> selectListItems = new List<SelectListItem>()
            {
                new SelectListItem() {Text = "--Select--", Value = ""}
            };
            foreach (Day aDay in days)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = aDay.Name;
                selectListItem.Value = aDay.Id.ToString();
                selectListItems.Add(selectListItem);
            }

            return selectListItems;
        }

        public List<ClassRoomScedule> GetClassRoomSceduleByDepartmentId(int departmentId)
        {
            return allocateClassRoomGateWay.GetClassRoomSceduleByDepartmentId(departmentId);
        }
		
		public string UnallocateRooms()
        {
            int rowAffect = allocateClassRoomGateWay.UnallocateRooms();
            if (rowAffect > 0)
            {
                return "All rooms unallocated";
            }
            return "No rooms to unallocate";
        }

    }
}