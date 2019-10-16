function BMIcalc()
 {

// Get input
//convert to numbers ig needed
//validate my inputs
//

var weight = document.getElementById('weight');
var height = document.getElementById('weight');



var w = parseInt(weight.value);
var h = parseInt(height.value);

h = h / 100

var errMsg = "";

if (weight <=0 )
{
  errMsg= errMsg + " Weight can't be negative \n"
}

if (height <=0 )
{
  errMsg= errMsg + " Height can't be negative  "
}


if (errMsg != "")

alert(errMsg)

 }else
 {
   var BMI = ((w)/(h*h));

var resultMsg = "";
 if (BMI < 19)

 resultMsg = "Your BMI is" + BMI.toFixed(2)+ "underweight";
alert(resultMsg;


 }

//Hides the return to original page button
$('#return-btn').hide();

//Form submission function
$('#theForm').submit(function (e) {
  e.preventDefault();

  //Takes in all the inputs from the form and assigns it so we can do some calculation with it  
  var w_weight = $('#weight').val();
  var h_height = $('#height').val();

  //BMI Formula 
  var ans = w_weight / Math.pow(h_height, 2);


  //Let's hide the form so we can make space to place result
  $("#theForm").hide();

  //This will show both the user input and the result that was calculated
  $("#hidden-containter").show();

  //Appends the use inputs
  $('#input-table').append("<tr><th>Information:</th></tr>");
  $('#input-table').append("<tr><td>Height: " + h_height + "cm.</td></tr>");
  $('#input-table').append("<tr><td>Weight: " + w_weight + "kg.</td></tr>");

  //Based off of the calculation, it will give you some advice
  if (ans < 18.5) {
    $('#summary').append("<li>Underweight</li>");
  }
  else if (ans >= 18.5 && ans <= 25) {
    $('#summary').append("<li>Normal</li>");
  }
  else if (ans > 30) {
    $('#summary').append("<li>Obese</li>");
  }
  else {
    $('#summary').append("<li>Overweight</li>");
  }

  //Allows users to return to the original input form pages
  $('#return-btn').show();
  $('#return-btn').click(function () {

    location.reload();
  });

});

);














