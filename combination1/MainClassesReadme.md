### Data Flow:
the csvReader holds a path to the csv file, loads it and  extracting and storing the data 
the model holds csvReader object it, then the model fills his properties using the csvReader.
the viewlmodel holds model object and binds the model properties to his properpties.
the view binds suitables wpf objects to the viewmodel properties and binds.

- #### Main Classes Description

 - ##### csvReader - a dedicated class for extracting the CSV file and uploading it to a data structure:
   - members: 
   - colNum - number of columns in the CSV
   - csvData - dictonary that holds the values of the whole CSV
   - fieldsNames - list that holds the attributes name's from the XML
   - fieldsNodes - list that holds the attributes node's from the XML

  - ##### pearsonCalc - helper class for mathematical calculations for task 8. Allows to calculate the following functions:
     - Average
     - Variance
     - Covariance
     - Pearson
     - Linear Regresion
     - Deviation

    classes:
      - Point - defines point with (x,y) values
      - Line - defines line with two points

  - ##### NativeMethods - helper methods from the kernel32.dll family for dll loading.
    Methods:
     - LoadLibrary - Its job is to load the dll file from the full routing
     - GetProcAddress - Its function is to return a pointer to the dll interface method, the findAnomalies method.
     - FreeLibrary - Releases the dll file after we finished using it

  - ##### GraphModel - A model for tasks 6-9:
    - properties: 
      - GraphCol - values of selected attribute to generate a suitable graph
      - CorrelativeGraphCol -values of selected attribute to generate a suitable graph
      - RegLine - line object to generate a suitable graph

    -  members:
       - csvReader - data structure object thats hold the csv file data
        - pearsCalc - an helper class object that calculates pearson between two features

  - ##### GraphViewModel - ViewModel for tasks 6-9
    - properties: 
        - VM_GraphCol - wraps the GraphCol property in GraphModel
        - VM_CorrelativeGraphCol -wraps the CorrelativeGraphCol property  in GraphModel
       - RegLine - wraps the RegLine property
       - Vm_GraphIndex - object that is bind to the view's comboBox and calls all graph generate methods when the user change the selection

    - members:
       - model - GraphModel object 
       - time - object that is bind to the flight's time stemp
       - originalFs - an object that is generating a suitsable graph to the selected column
       - corelFs -an object that is generating a suitsable graph to the correlated selected column
       - regFs - an object that is generating a suitable graph to the reg line object

  - ##### MainWindow (view) - view for tasks 6-9
     - Gvm - graph view model object
     - Data context - binding the XAML to the GVM

     Features & Functionality:
     - Combobox - holds the attributes names and allowing the user to pick them
     - dllTextBox - the place to enter the path for the dll
     - dllButton - operating the searching and loading the dll file, and also presents the results in the dllDaraGrid
     - dllDaraGrid - presents the results of the detection algorithm in a table
     - algoTextBox - present the name of chosen algorithm

     ![graph](https://user-images.githubusercontent.com/72969386/114574651-1b24a500-9c82-11eb-8e1d-d00be64c2396.png)

    ### The Controllers
    - ##### Joystick
    - In this component, we implemented a joystick which moves according to the values of the "aileron", "elevators", "rudder" and "throttle" fields.
    - The values of the "throttle" and "rudder" fields are presentd on the sliders.
    - The values of the "aileron" and "elevator" fields are presented by the joystick movement.
    
    ![joystick](https://user-images.githubusercontent.com/72969386/114574264-c719c080-9c81-11eb-881f-023efff7e4e6.png)

    - ##### Flight Details
    - In this component, we present details about the flight of various fields such as: "speed", "height", "pitch", "roll", "yaw" and also a compass which shows the direction of the aircraft during the flight.
    - The values of the "pitch", "roll" and "yaw" fields during the flight are presented on the sliders.
    - The "speed" and "height" are presented by their real number value.
    - The compass shows the direction of the aircraft by the the angle from it's canter

    ![info](https://user-images.githubusercontent.com/72969386/114574477-f4666e80-9c81-11eb-8a7c-1ca5a1bb7bcc.png)

    - ##### Time Slider
    - In this component, the user can control the current time and state the simulation - the simulation can be stopped/resumed, displayed faser/slower, and more.
    - the time of the simulation(by the speed that we decided) is a minute and 48 seconds. the user is able to move the slider on the screen to change the time of the simulation and by that to update all the components.
    
    ![slider](https://user-images.githubusercontent.com/72969386/114574587-0cd68900-9c82-11eb-8100-8655e650affe.png)

    - ##### FG Communication
    - In this component, all the communication with the "FlightGear" app is happening. As our program is launching the FG app menu is launching as well, and after setting the settings for our program in the FG app(see README) the user can press "Fly!" and start loading the flight visual simulation on the FG window.
    - While the FG is loading, the user can decide to start the simulation and by that all the components will react regularly instead of the FG which is loading. When loading, the visual flight simulation on the FG app will start from the current point that all the components are on.
    - Notes: 1) By pressing the "Exit" button on the main window - the FG window will also close with the main window.
          2 )Tip: For better preformence - Wait 5 seconds after pressing "Fly!" on the FG window before starting the simulation - in order the connection to complete.
    
    ![flightgear](https://user-images.githubusercontent.com/72969386/114574623-13fd9700-9c82-11eb-81ca-4381ad88b40e.png)
