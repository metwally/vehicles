var timer_interval = 60000;

var timer_vehicles =[];

function starttimer_vehicles(VehicleID){

    stoptimer_vehicles(VehicleID);
    timer_vehicles.push({VehicleID: VehicleID, timer: setTimeout(function(){ reset_vehicle(VehicleID);}, timer_interval)});

}
function stoptimer_vehicles(VehicleID){
    for(i = 0; i < timer_vehicles.length; i++){
        if(timer_vehicles[i].VehicleID == VehicleID)
        {
            clearTimeout(timer_vehicles[i].timer);
            timer_vehicles.splice(i, 1);
            break;
        }
    }
}
function reset_vehicle(VehicleID){
    var id = 'row_' + VehicleID;

    var el_vehicle = document.getElementById(id);
    if (el_vehicle == null) return;

    var vehicle = $(el_vehicle);
    vehicle.removeClass('red');
    vehicle.removeClass('warn');
    vehicle.removeClass('green');
    vehicle.addClass('dim');
}
9