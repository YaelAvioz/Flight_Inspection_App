### The Controllers
- ##### Joystick
In this component, we implemented a joystick which moves according to the values of the "aileron", "elevators", "rudder" and "throttle" fields.
The values of the "throttle" and "rudder" fields are presentd on the sliders.
The values of the "aileron" and "elevator" fields are presented by the joystick movement.

PICTURE
- ##### Flight Details
In this component, we present details about the flight of various fields such as: "speed", "height", "pitch", "roll", "yaw" and also a compass which shows the direction of the aircraft during the flight.
The values of the "pitch", "roll" and "yaw" fields during the flight are presented on the sliders.
The "speed" and "height" are presented by their real number value.
The compass shows the direction of the aircraft by the the angle from it's canter

PICTURE

- ##### Time Slider
In this component, the user can control the current time and state the simulation - the simulation can be stopped/resumed, displayed faser/slower, and more.
the time of the simulation(by the speed that we decided) is a minute and 48 seconds. the user is able to move the slider on the screen to change the time of the simulation and by that to update all the components.

- ##### FG Communication
In this component, all the communication with the "FlightGear" app is happening. As our program is launching the FG app menu is launching as well, and after setting the settings for our program in the FG app(see README) the user can press "Fly!" and start loading the flight visual simulation on the FG window.
While the FG is loading, the user can decide to start the simulation and by that all the components will react regularly instead of the FG which is loading. When loading, the visual flight simulation on the FG app will start from the current point that all the components are on.
Note: By pressing the "Exit" button on the main window - the FG window will also close with the main window.
