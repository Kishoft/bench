
import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
  stages: [
    { duration: '1s', target: 200 },
    { duration: '9s', target: 700 },
  ]
};

export default function () {
  const res = http.post('http://127.0.0.1:3300/tttt', JSON.stringify({
    "name": "eze",
    "email": "asdasda@asdada.com"
  }), { headers: { 'Content-Type': 'application/json' } });
  check(res, { 'status was 204': (r) => r.status == 204 });
}