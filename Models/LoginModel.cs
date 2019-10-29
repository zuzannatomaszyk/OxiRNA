namespace OxiRNA.Models {
  using System.ComponentModel.DataAnnotations;
  using System;

  public class LoginModel {
    public string email { get; set; }

    public string password { get; set; }
  }
}