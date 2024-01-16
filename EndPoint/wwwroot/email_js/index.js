function sendMail() {
  var params = {
      name: document.getElementById("name").value,
      email: document.getElementById("email").value,
      message: document.getElementById("message").value,
      subject: document.getElementById("subject").value,
      whatsop: document.getElementById("whatsop").value,
      product: document.getElementById("product").value,
      contry: document.getElementById("contry").value,

  };
  const serviceID = "service_gplf1ys";
  const templateID = "template_1qnjnhi";

  emailjs.send(serviceID, templateID, params)
    .then(res => {
        document.getElementById("name").value = "";
        document.getElementById("email").value = "";
        document.getElementById("message").value = "";
        document.getElementById("subject").value = "";
        document.getElementById("whatsop").value = "";
        document.getElementById("product").value = "";
        document.getElementById("contry").value = "";
        console.log(res);
        alert("Your message sent successfully!!")

    })
    .catch(err => console.log(err));

}