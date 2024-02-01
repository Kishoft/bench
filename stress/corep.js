
import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
  stages: [
    { duration: '10s', target: 10000 },
  ],
};

export default function () {
  const res = http.post('http://127.0.0.1:6000/user', JSON.stringify({
    "firstName": "eze",
    "lastName": "quiel",
    "email": "asdasda@asdada.com"
  }), { headers: { 'Content-Type': 'application/json' } });
  check(res, { 'status was 200': (r) => r.status == 200 });
  sleep(1);
}