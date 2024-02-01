
import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
  stages: [
    { duration: '1s', target: 10000 },
    { duration: '1s', target: 10000 },
    { duration: '1s', target: 10000 },
    { duration: '1s', target: 10000 },
    { duration: '1s', target: 10000 },
    { duration: '1s', target: 10000 },
    { duration: '1s', target: 10000 },
    { duration: '1s', target: 10000 },
    { duration: '1s', target: 10000 },
    { duration: '1s', target: 10000 },
    { duration: '1s', target: 10000 },
    { duration: '1s', target: 10000 },
    { duration: '1s', target: 10000 },
    { duration: '1s', target: 10000 },
    { duration: '1s', target: 10000 },
    { duration: '1s', target: 10000 },
    { duration: '1s', target: 10000 },
    { duration: '1s', target: 10000 },
    { duration: '1s', target: 10000 },
    { duration: '1s', target: 10000 },
  ],
};

export default function () {
  const res = http.post('http://192.168.1.39:3000/user', JSON.stringify({
    "firstName": "eze",
    "lastName": "quiel",
    "email": "asdasda@asdada.com"
  }), { headers: { 'Content-Type': 'application/json' } });
  check(res, { 'status was 201': (r) => r.status == 201 });
  sleep(1);
}