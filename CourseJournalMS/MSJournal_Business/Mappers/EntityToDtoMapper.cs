using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Business.Dtos;
using MSJournal_Data.Models;

namespace MSJournal_Business.Mappers
{
    internal class EntityToDtoMapper
    {
        public static StudentDto StudentEntityModelToDto(Student student)
        {
            return new StudentDto()
            {

                
            };
        }

        public static CourseDayDto CourseDayEntityModelToDto(CourseDay courseDay)
        {
            return new CourseDayDto()
            {
                
            };
        }

    }
}
