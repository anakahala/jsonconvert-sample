using System;
using System.Collections.Generic;
using System.Text;

namespace WpfJsonConverterSample
{
    /// <summary>
    /// User Model
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// CreatedDateTime
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public DateTime CreatedDateTime { get; set; }

        /// <summary>
        /// User Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// User Name
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Birth Day
        /// </summary>
        public DateTime BirthDay { get; set; }

        /// <summary>
        /// Family
        /// </summary>
        public List<UserModel> Family { get; set; } = new List<UserModel>();

        /// <summary>
        /// FamilyCount
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public int FamilyCount
        {
            get
            {
                return this.Family.Count;
            }
        }
    }
}
