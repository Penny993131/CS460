//Always test and confirm the page is ready and loaded properly
$(document).ready(function(){


    //Just a test message to see if everything ran correctly
   console.log("Loaded Successfully");

 //Hides the return to original page button
 $('#return-btn').hide();

  //Form submission function
  $('#theForm').submit(function(e){
    e.preventDefault();

  //Takes in all the inputs from the form and assigns it so we can do some calculation with it  
  var weight = $('#weight').val();
  var height = $('#height').val();

   //BMI Formula 
   var ans = weight/Math.pow(height,2);

//   //Formula of BMI

// function computeBMI()
// {
//      //Obtain user inputs
//      var height=Number(document.getElementById("height").value);
//      var heightunits=document.getElementById("heightunits").value;
//      var weight=Number(document.getElementById("weight").value);
//      var weightunits=document.getElementById("weightunits").value;


//      //Convert all units to metric
//      if (heightunits=="inches") height/=39.3700787;
//      if (weightunits=="lb") weight/=2.20462;

//   //Perform calculation
//   var BMI=weight/Math.pow(height,2);


//    //Display result of calculation
//    document.getElementById("output").innerText=Math.round(BMI*100)/100;

//    var output =  Math.round(BMI*100)/100
//    if (output<18.5)
//    document.getElementById("comment").innerText = "Underweight";
//  else   if (output>=18.5 && output<=25)
//    document.getElementById("comment").innerText = "Normal";
// else   if (output>=25 && output<=30)
//    document.getElementById("comment").innerText = "Obese";
// else   if (output>30)
//    document.getElementById("comment").innerText = "Overweight";
//   // document.getElementById("answer").value = output; 
// }

 //Let's hide the form so we can make space to place result
 $("#myForm").hide();

   //This will show both the user input and the result that was calculated
   $("#hidden-containter").show();

    //Appends the use inputs
    $('#input-table').append("<tr><th>Data Entered:</th></tr>");
    $('#input-table').append("<tr><td>Height: " + height + "cm.</td></tr>");
    $('#input-table').append("<tr><td>Weight: " + weight + "kg.</td></tr>");

   //Based off of the calculation, it will give you some advice
   if(ans < 18.5){
    $('#summary').append("<li>Underweight</li>");
}
else if(ans>=18.5 && ans<=25  ){
    $('#summary').append("<li>Normal</li>");

    else if(ans>30  ){
        $('#summary').append("<li>Obese</li>");
        else if(ans>=25 && ans<=30  ){
            $('#summary').append("<li>Overweight</li>");
}

//Allows users to return to the original input form pages
$('#return-btn').show();
$('#return-btn').click(function() {

    location.reload();
});

});

});
