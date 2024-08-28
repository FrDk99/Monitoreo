docker run -d \
  --name prometheus \
  -p 9090:9090 \
  -v "D:/Programacion/Proyectos Github/Telemetria/prometheus.yml:/etc/prometheus/prometheus.yml" \
  prom/prometheus:v2.54.1
