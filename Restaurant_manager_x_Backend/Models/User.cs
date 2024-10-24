using System.ComponentModel.DataAnnotations;
namespace Restaurant_manager_x_backend.Models {

    public class User {
        [Key]
        public int id {get;set;}
        private string username {get;set;}
        private string password {get;set;}
        public string mail {get;set;}
        private string[] roles {get; set;}

        public User () {
            username = string.Empty;
            password = string.Empty;
            mail = string.Empty;
            roles = [];
        }

        private User (string username, string password, string mail, string[] roles) {
            this.username = username;
            this.password = password;
            this.mail = mail;
            this.roles = roles;
        }
        // Public getter methods
        public int GetId() {
            return id;
        }

        public string GetUsername() {
            return username;
        }

        public string GetPassword() {
            return password;
        }

        public string[] GetRoles() {
            return roles;
        }

        // Public setter methods
        public void SetId(int id) {
            this.id = id;
        }

        public void SetUsername(string username) {
            this.username = username;
        }

        public void SetPassword(string password) {
            this.password = password;
        }

        public void SetRoles(string[] roles) {
            this.roles = roles;
        }

        // Validate password
        public bool ValidatePassword(string password) {
            return this.password == password;
        }

        // Check if user has a specific role
        public bool HasRole(string role) {
            return roles.Contains(role);
        }

        // Add a role to the user
        public void AddRole(string role) {
            if (!roles.Contains(role)) {
                var rolesList = roles.ToList();
                rolesList.Add(role);
                roles = rolesList.ToArray();
            }
        }

        // Remove a role from the user
        public void RemoveRole(string role) {
            if (roles.Contains(role)) {
                var rolesList = roles.ToList();
                rolesList.Remove(role);
                roles = rolesList.ToArray();
            }
        }

    }
}