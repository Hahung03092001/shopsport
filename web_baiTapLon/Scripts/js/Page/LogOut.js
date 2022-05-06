document.querySelector(".clickLogout").addEventListener("click", (e) => {
    firebase
    .auth()
    .signOut()
    .then(() => {
      // Sign-out successful.
      console.log("Sign out  successful");
        window.location = "../login/Index";
    })
    .catch((error) => {
      // An error happened.
      console.log(error.message);
    });
  });