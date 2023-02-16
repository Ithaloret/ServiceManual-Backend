<div class="markdown prose w-full break-words dark:prose-invert dark">
   <h2>EtteplanMORE.ServiceManual.Web API</h2>
      <p>Backend for a factory service manual</p>
   <p>Instructions are intended for Visual Studio 2022</p>
   <h5>Based on https://github.com/etteplanmore/servicemanual-csharp</h5>

  <h3> Creating the Database using Entity Framework Core</h3>
  <ul>
    <li>Change the 'Data Source' of ConnectionStrings in <code>appsettings.json file</code></li> to reflect your database server if necessary. Current implementation was done for a local MS SQL Server instance.
    <li>Open the package manager console and select Project <code>EtteplanMORE.ServiceManual.ApplicationCore</code></li>
    <li>Run the following command for creating a migration <code>add-migration < migration name > </code></li>
    <li>Run the following command to update the database <code>Update-database</code></li>
    <li>Run EtteplanMore.ServiceManual.Web to test the endpoints with Swagger</li>
  </ul>
   <h3>Base URL</h3>
   <p><code>https://localhost:57571</code></p>
   <h3>Swagger-UI URL</h3>
   <p><code>https://localhost:57571/swagger/index.html</code></p>
   <h3>Authentication</h3>
   <p>No authentication is required to access the endpoints of this API.</p>
   
   <h3>Endpoints</h3>
   <h4>GET <code>/api/FactoryDevices</code></h4>
   <p>The endpoint returns a list of all the factory devices in the system. The response will be an array of <code>FactoryDeviceDto</code> objects.</p>
   <h5>Response</h5>
   <ul>
      <li><code>200 OK</code> - The list of devices is returned in the response body.</li>
   </ul>
   <h4>GET <code>/api/FactoryDevices/{id}</code></h4>
   <p>This endpoint returns the details of a specific factory device. The <code>id</code> parameter must be a valid UUID.</p>
   <h5>Parameters</h5>
   <ul>
      <li><code>id</code> (required) - The UUID of the device to be retrieved.</li>
   </ul>
   <h5>Response</h5>
   <ul>
      <li><code>200 OK</code> - The device details are returned in the response body.</li>
   </ul>
   <h4>GET <code>/api/MaintenanceTask/GetList</code></h4>
   <p>This endpoint returns a list of all the maintenance tasks in the system. The response will be an array of <code>MaintenanceTask</code> objects.</p>
   <h5>Response</h5>
   <ul>
      <li><code>200 OK</code> - The list of maintenance tasks is returned in the response body.</li>
   </ul>
   <h4>GET <code>/api/MaintenanceTask/GetMaintenanceTasksByDeviceId/{DeviceId}</code></h4>
   <p>This endpoint returns a list of maintenance tasks for a specific device. The <code>DeviceId</code> parameter must be a valid UUID.</p>
   <h5>Parameters</h5>
   <ul>
      <li><code>DeviceId</code> (required) - The UUID of the device to retrieve maintenance tasks for.</li>
   </ul>
   <h5>Response</h5>
   <ul>
      <li><code>200 OK</code> - The list of maintenance tasks for the specified device is returned in the response body.</li>
   </ul>
   <h4>GET <code>/api/MaintenanceTask/GetMaintenanceTaskById/{TaskId}</code></h4>
   <p>This endpoint returns the details of a specific maintenance task. The <code>TaskId</code> parameter must be a valid UUID.</p>
   <h5>Parameters</h5>
   <ul>
      <li><code>TaskId</code> (required) - The UUID of the maintenance task to retrieve.</li>
   </ul>
   <h5>Response</h5>
   <ul>
      <li><code>200 OK</code> - The maintenance task details are returned in the response body.</li>
   </ul>
   <h4>POST <code>/api/MaintenanceTask/CreateMaintenanceTask</code></h4>
   <p>This endpoint creates a new maintenance task.</p>
   <h5>Request Body</h5>
   <p>The request body must be a <code>CreateMaintenanceTaskRequest</code> object.</p>
   <h5>Response</h5>
   <ul>
      <li><code>200 OK</code> - The maintenance task was created successfully.</li>
   </ul>
   <h4>POST <code>/api/MaintenanceTask/UpdateMaintenanceTask</code></h4>
   <p>This endpoint updates an existing maintenance task.</p>
   <h5>Request Body</h5>
   <p>The request body must be an <code>UpdateMaintenanceTaskRequest</code> object.</p>
   <h5>Response</h5>
   <ul>
      <li><code>200 OK</code> - The maintenance task was updated successfully.</li>
   </ul>
   <h4>DELETE <code>/api/MaintenanceTask/DeleteMaintenanceTask</code></h4>
   <p>This endpoint delete the specified the Maintenance Task. The <code>TaskId</code> parameter must be a valid UUID.</p>
   <h5>Parameters</h5>
   <ul>
      <li><code>TaskId</code> (required) - The UUID of the maintenance task to delete.</li>
   </ul>
   <h5>Response</h5>
   <ul>
      <li><code>200 OK</code> - The Maintenance task has been deleted</li>
   </ul>
</div>
