
import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
  stages: [
    { duration: '10s', target: 50000 },
  ],
};

export default function () {
  const res = http.get('http://127.0.0.1:6000/test', JSON.stringify({
    "firstName": "eze",
    "lastName": "quiel",
    "email": "asdasda@asdada.com"
  }), { headers: { 'Content-Type': 'application/json' } });
  check(res, { 'status was 204': (r) => r.status == 204 });
  sleep(1);
}