Project.configure do |project|
  project.scheduler.polling_interval = 1.minute

  case project.name
  when "client_library_dotnet_integration_master"
    project.build_command = "CRUISE_BUILD=#{project.name} GATEWAY_URL='http://localhost:6010' SPHINX_PORT=6322 rake cruise"
    project.triggered_by :gateway_master
  end
end

