﻿
function validate() {

  var flag = true;
  var email = document.login.email.value;

  if (email === "") {
    document.getElementById("e_error").innerHTML = "Email Field cannot be empty!!";
    flag = false;
  } else if (!(email.indexOf("@") > 0 && (email.lastIndexOf(".") > email.indexOf("@") + 1) && (email.length > email.lastIndexOf(".") + 1))) {
    document.getElementById("e_error").innerHTML = "Please enter a valid Email!!";
    flag = false;
  } else {
    document.getElementById("e_error").innerHTML = "";
    flag = true;
  }

  var flag1 = true;
  if (document.login.password.value === "") {
    document.getElementById("p_error").innerHTML = "Password cannot be empty!!";
    document.login.password.focus();
    flag1 = false;
  } else if (document.login.passwd.value.length < 3) {
    document.getElementById("p_error").innerHTML = "Cannot be less than 3 characters!!";
    document.login.password.focus();
    flag1 = false;
  } else {
    document.getElementById("p_error").innerHTML = "";
    flag1 = true;
  }

  console.log("chekcing teh data", flag && flag1);
  return flag && flag1;
}