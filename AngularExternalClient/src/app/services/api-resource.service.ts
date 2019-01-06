import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiResourceService {

  constructor(
    private http: HttpClient
  ) {
  }
  public getCustomers() {
    const url = 'http://localhost:5001/api/Customers';
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
        'Authorization': 'Bearer eyJhbGciOiJSUzI1NiIsImtpZCI6ImNkMGNmNzIyZDA1ZWE4NDE5ZmU5YTk1MmQwYjQ1YmRmIiwidHlwIjoiSldUIn0.eyJuYmYiOjE1NDY4MDgzNTIsImV4cCI6MTU0NjgxMTk1MiwiaXNzIjoiaHR0cDovL2lkZW50aXR5c2VydmVyIiwiYXVkIjpbImh0dHA6Ly9pZGVudGl0eXNlcnZlci9yZXNvdXJjZXMiLCJBcGlSZXNvdXJjZSJdLCJjbGllbnRfaWQiOiJyby5jbGllbnQiLCJzdWIiOiIxIiwiYXV0aF90aW1lIjoxNTQ2ODA4MzUyLCJpZHAiOiJsb2NhbCIsInNjb3BlIjpbIkFwaVJlc291cmNlIl0sImFtciI6WyJwd2QiXX0.eESGkAGeqSxo1tHL8T_EgrSreQN1mXH3uMf2QYPO_ZwXrbS3NypCAVh0g6_0objFBEApk6Pqh50zhIkBYCmbev0bGXAmrJgb2Hm5GYXLzi90YFdQMxLL72dNpPI9mlIR8RKIdJe9loCOaGrnQfRSaAIf7ifN6cIZpH3G_Uf8C2ih9nAU67x4U_yF-c_3Tbh9VpETfzUwtqFWtrtLNzqE2mczvwrKopqF1pOw9NvYyrf-qT9jUuYluUKQsjnfwGfZhUHpFS9z5S3w_7G1UNymaAU0hqy8noL2pA_KzosuK0nIz5sXqWRhlWfZzBSoo6FDf0hYkpM11KcBy6743lgkZQ'
      })
    };
    return this.http.get(url, httpOptions);
  }
}
