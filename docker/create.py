import os
from mlflow import log_metric, log_param, log_artifact
import mlflow

if __name__ == "__main__":
    mlflow.set_tracking_uri("http://localhost:5000")
    mlflow.create_experiment("jordantest")
   