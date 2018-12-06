import os
from mlflow import log_metric, log_param, log_artifact
import mlflow

if __name__ == "__main__":
    
    mlflow.set_tracking_uri("http://localhost:5000")
    
    # Log a parameter (key-value pair)
    log_param("param1", 5)

    # Log a metric; metrics can be updated throughout the run
    log_metric("foo", 1)
    log_metric("foo", 2)
    log_metric("foo", 3)

    # Log an artifact (output file)
    with open("output.txt", "w") as f:
        f.write("Hello world!")
    log_artifact("output.txt")
